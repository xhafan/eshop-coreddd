using System.Threading.Tasks;
using NUnit.Framework;
using Shouldly;

namespace CoreMvvm.UnitTests.RelayCommandAsyncs
{
    [TestFixture]
    public class when_can_execute_with_value_object_parameter
    {
        private object _executeParameter;

        private async Task ExecuteAsync(int obj) {}

        private void CheckExecuteParameter(int obj)
        {
            obj.ShouldBe(0);
        }

        [TestCase(false)]
        [TestCase(true)]
        public void can_execute(bool canExecute)
        {
            var relayCommand = new RelayCommandAsync<int>(async obj => await ExecuteAsync(obj), obj =>
                {
                    CheckExecuteParameter(obj);
                    return canExecute;
                });
            _executeParameter = null;

            relayCommand.CanExecute(_executeParameter).ShouldBe(canExecute);
        }
    }
}