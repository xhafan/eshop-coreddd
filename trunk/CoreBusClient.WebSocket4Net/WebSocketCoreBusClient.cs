using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;
using SuperSocket.ClientEngine;
using WebSocket4Net;

namespace CoreBusClient.WebSocket4Net
{
    public class WebSocketCoreBusClient : CoreBusClient
    {
        private readonly string _uri;
        private readonly BlockingCollection<string> _outbox = new BlockingCollection<string>();
        private readonly Task _sendMessagesTask;
        private readonly CancellationTokenSource _cancellationTokenSource = new CancellationTokenSource();
        private readonly CancellationToken _cancellationToken;

        private WebSocket _webSocket;
        private ManualResetEvent _waitForWebSocketOpening;

        public WebSocketCoreBusClient(string uri)
        {
            _uri = uri;
            _cancellationToken = _cancellationTokenSource.Token;
            _sendMessagesTask = Task.Factory.StartNew(SendMessagesToServer, TaskCreationOptions.LongRunning);
        }

        private void SendMessagesToServer()
        {
            try
            {
                while (!_cancellationToken.IsCancellationRequested)
                {
                    var message = _outbox.Take(_cancellationToken);
                    TrySendOneMessageToServer(message);
                }
            }
            catch (OperationCanceledException)
            {
            }
        }

        private void TrySendOneMessageToServer(string message)
        {
            while (!_cancellationToken.IsCancellationRequested)
            {
                try
                {
                    _reconnectIfNeeded();
                    _webSocket.Send(message);
                    break;
                }
// ReSharper disable once EmptyGeneralCatchClause
                catch
                {
                }
            }
        }

        public override void Send(string message)
        {
// ReSharper disable once MethodSupportsCancellation
            _outbox.Add(message);
        }

        private void _reconnectIfNeeded()
        {
            if (!_webSocketIsClosed()) return;

            _waitForWebSocketOpening = new ManualResetEvent(false);
            _webSocket = new WebSocket(_uri);
            _webSocket.Opened += (sender, args) => _waitForWebSocketOpening.Set();
            _webSocket.Closed += _onClosed;
            _webSocket.Error += _onError;
            _webSocket.MessageReceived += _onMessageReceived;
            _webSocket.Open();
            if (_isConnectionTimeoutOrConnectionCancelled() || _webSocketIsClosed())
            {
                _tryCloseExistingWebSocket();
                throw new TimeoutException("websocket opening timeout");
            }
        }

        private bool _isConnectionTimeoutOrConnectionCancelled()
        {
            return WaitHandle.WaitAny(new [] { _waitForWebSocketOpening, _cancellationToken.WaitHandle }, 5000) != 0;
        }

        private bool _webSocketIsClosed()
        {
            return _webSocket == null;
        }

        private void _tryCloseExistingWebSocket()
        {
            var webSocket = _webSocket;
            if (webSocket == null) return;
            webSocket.Closed -= _onClosed;
            webSocket.Error -= _onError;
            webSocket.MessageReceived -= _onMessageReceived;
            _disposeWebSocket();                
        }

        private void _onClosed(object sender, EventArgs eventArgs)
        {
            _tryCloseExistingWebSocket();
        }

        private void _onError(object sender, ErrorEventArgs errorEventArgs)
        {
            _tryCloseExistingWebSocket();
            if (_waitForWebSocketOpening != null) _waitForWebSocketOpening.Set();
        }

        private void _onMessageReceived(object sender, MessageReceivedEventArgs messageReceivedEventArgs)
        {
            OnReceived(messageReceivedEventArgs.Message);
        }

        public override void Close()
        {
            _cancelSendMessagesTask();
            _disposeWebSocket();
        }

        public override void Dispose()
        {
            _cancelSendMessagesTask();
            _disposeWebSocket();
        }

        private void _cancelSendMessagesTask()
        {
            _cancellationTokenSource.Cancel();
// ReSharper disable once MethodSupportsCancellation
            _sendMessagesTask.Wait();
        }

        private void _disposeWebSocket()
        {
            var webSocket = _webSocket;
            if (webSocket == null) return;
            ((IDisposable) webSocket).Dispose();
            _webSocket = null;
        }
    }
}