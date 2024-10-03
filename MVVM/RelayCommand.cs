using System.Windows.Input;

namespace DemoProject.MVVM
{
    class RelayCommand : ICommand
    {
        private Action<object> _execute;
        private Func<object, bool>? _canExecute;

        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove {  CommandManager.RequerySuggested -= value; }
        }

        public RelayCommand(Action<object> execute,
                            Func<object, bool>? canExecute = null)
        {
            this._execute = execute;
            this._canExecute = canExecute;
        }

        // Assume we can execute if no function for _canExecute is provided,
        // otherwise we can ask the provided Func with the supplied parameter
        // if we can execute.
        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || CanExecute(parameter);
        }

        // Invoke the supplied Action
        public void Execute(object? parameter)
        {
            _execute(parameter);
        }
    }
}
