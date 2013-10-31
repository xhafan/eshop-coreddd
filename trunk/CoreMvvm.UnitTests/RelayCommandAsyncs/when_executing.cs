using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace CoreMvvm.UnitTests.RelayCommandAsyncs
{
    [TestFixture]
    public class when_executing
    {
        private object _executeParameter;
        private object _retrievedExecuteParameter;
        private RelayCommandAsync<object> _relayCommand;

        private async Task ExecuteAsync(object obj)
        {
            _retrievedExecuteParameter = obj;
        }

        [SetUp]
        public void Context()
        {
            _relayCommand = new RelayCommandAsync<object>(async obj => await ExecuteAsync(obj));

            _executeParameter = new object();
            _relayCommand.Execute(_executeParameter);
        }

        [Test]
        public void command_is_executed()
        {
            _retrievedExecuteParameter.ShouldBe(_executeParameter);
        }
    }
}
