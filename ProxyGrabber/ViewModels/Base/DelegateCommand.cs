using System;
using System.Windows.Input;

namespace ProxyGrabber.ViewModels.Base {
    public class DelegateCommand : ICommand{
        Action<object> execute;
        Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter) {
            canExecute?.Invoke(parameter);
            return true;
        }

        public void Execute(object parameter) {
            execute?.Invoke(parameter);
        }

        public DelegateCommand(Action<object> executeAction) : this(executeAction, null) { }

        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc) {
            this.execute = executeAction;
            canExecute = canExecuteFunc;
        }
    }
}