using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Icl.Mvvm.Async
{
    using Nito.Mvvm;

    public abstract class AsyncCommandBase : IAsyncCommand
    {
        private readonly ICanExecuteChanged canExecuteChanged;

        protected AsyncCommandBase(Func<object, ICanExecuteChanged> canExecuteChangedFactory) =>
            canExecuteChanged = canExecuteChangedFactory(this);

        event EventHandler ICommand.CanExecuteChanged
        {
            add => canExecuteChanged.CanExecuteChanged += value;
            remove => canExecuteChanged.CanExecuteChanged -= value;
        }

        public abstract Task ExecuteAsync(object parameter);

        bool ICommand.CanExecute(object parameter) => CanExecute(parameter);

        async void ICommand.Execute(object parameter)
        {
            await ExecuteAsync(parameter).ConfigureAwait(true);
        }

        protected void OnCanExecuteChanged()
        {
            canExecuteChanged.OnCanExecuteChanged();
        }

        protected abstract bool CanExecute(object parameter);
    }
}