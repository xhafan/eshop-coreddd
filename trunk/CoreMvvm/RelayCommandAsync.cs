using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CoreMvvm
{
    // inspired by 
    // http://msdn.microsoft.com/en-us/magazine/dd419663.aspx#id0090051
    // http://blog.mycupof.net/2012/08/23/mvvm-asyncdelegatecommand-what-asyncawait-can-do-for-uidevelopment/
    public class RelayCommandAsync<TParam> : ICommand
    {
        private readonly Func<TParam, Task> _asyncExecute;
        private readonly Predicate<TParam> _canExecute;

        public RelayCommandAsync(Func<TParam, Task> asyncExecute)
            : this(asyncExecute, null)
        {
        }

        public RelayCommandAsync(Func<TParam, Task> asyncExecute, Predicate<TParam> canExecute)
        {
            if (asyncExecute == null) throw new ArgumentNullException("asyncExecute");
            _asyncExecute = asyncExecute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute((TParam)parameter);
        }

        public async void Execute(object parameter)
        {
            await _asyncExecute((TParam)parameter);
        }
    }
}