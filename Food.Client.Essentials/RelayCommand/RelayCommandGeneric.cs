using System;
using System.Windows.Input;

namespace Food.Client.Essentials.RelayCommand
{
    public class RelayCommand<T> : ICommand
    {
        private readonly Action<T> execute;

        private readonly Predicate<T> canExecute;

        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {
        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (canExecute == null) return;
                CommandManager.RequerySuggested += value;
            }

            remove
            {
                if (canExecute == null) return;
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object parameter) => canExecute?.Invoke((T)parameter) ?? true;

        public void Execute(object parameter) => execute((T)parameter);
    }
}
