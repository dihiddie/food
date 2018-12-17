namespace Icl.Mvvm.Async
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Nito.Mvvm;

    public class CancellableCustomAsyncCommand : CustomAsyncCommand, ICancellableAsyncCommand
    {
        public CancellableCustomAsyncCommand(
            Func<object, CancellationToken, Task> executeAsync,
            Func<object, bool> canExecute,
            Func<object, ICanExecuteChanged> canExecuteChangedFactory)
            : base(_ => Task.CompletedTask, canExecute, canExecuteChangedFactory)
            => SetExecutingFunc(CancelCommand.Wrap(executeAsync));

        public CancellableCustomAsyncCommand(
            Func<object, CancellationToken, Task> executeAsync,
            Func<object, bool> canExecute)
            : base(_ => Task.CompletedTask, canExecute)
            => SetExecutingFunc(CancelCommand.Wrap(executeAsync));

        public CancellableCustomAsyncCommand(
            Func<CancellationToken, Task> executeAsync,
            Func<bool> canExecute,
            Func<object, ICanExecuteChanged> canExecuteChangedFactory)
            : base(() => Task.CompletedTask, canExecute, canExecuteChangedFactory)
            => SetExecutingFunc(CancelCommand.Wrap(executeAsync));

        public CancellableCustomAsyncCommand(Func<CancellationToken, Task> executeAsync, Func<bool> canExecute)
            : base(() => Task.CompletedTask, canExecute)
            => SetExecutingFunc(CancelCommand.Wrap(executeAsync));

        public CancelCommand CancelCommand { get; } = new CancelCommand();

        public void Cancel() => CancelCommand.Cancel();
    }
}
