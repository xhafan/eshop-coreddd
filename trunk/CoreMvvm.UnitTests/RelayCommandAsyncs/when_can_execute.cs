using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace CoreMvvm.UnitTests.RelayCommandAsyncs
{
    [TestFixture]
    public class when_can_execute
    {
        private object _executeParameter;

        private async Task ExecuteAsync(object obj) {}

        private void CheckExecuteParameter(object obj)
        {
            obj.ShouldBe(_executeParameter);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void can_execute(bool canExecute)
        {
            var relayCommand = new RelayCommandAsync<object>(async obj => await ExecuteAsync(obj), obj =>
                {
                    CheckExecuteParameter(obj);
                    return canExecute;
                });
            _executeParameter = new object();

            relayCommand.CanExecute(_executeParameter).ShouldBe(canExecute);
        }
    }
}