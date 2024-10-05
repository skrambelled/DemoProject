using System;
using System.Windows.Input;

namespace DemoProject.MVVM
{
    internal class RelayCommand : ICommand
    {

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value; }
        }

        // Internal variables to store a reference to an Actio and an optional Func to test
        // if we should be able to execute the Action.
        private Action<object> _execute;
        private Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute,
                            Func<object, bool> canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        // Assume we can execute if no function for _canExecute is provided,
        // otherwise we can ask the provided Func with the supplied parameter
        // if we can execute.
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        // Invoke the supplied Action
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
