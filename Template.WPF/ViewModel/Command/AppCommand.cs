using System;
using System.Windows.Input;

namespace Template.WPF.ViewModel.Command
{
    public class AppCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        Action _execute;

        public AppCommand(Action execute)
        {
            _execute = execute;
        }

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            _execute.Invoke();
        }
    }
}
