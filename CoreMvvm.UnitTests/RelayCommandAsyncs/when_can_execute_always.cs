using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace CoreMvvm.UnitTests.RelayCommandAsyncs
{
    [TestFixture]
    public class when_can_execute_always
    {
        private RelayCommandAsync<object> _relayCommand;
        private bool _canExecute;

        private async Task ExecuteAsync(object obj) {}

        [SetUp]
        public void Context()
        {
            _relayCommand = new RelayCommandAsync<object>(async obj => await ExecuteAsync(obj));

            _canExecute = _relayCommand.CanExecute(null);
        }

        [Test]
        public void can_always_execute()
        {
            _canExecute.ShouldBe(true);
        }
    }
}