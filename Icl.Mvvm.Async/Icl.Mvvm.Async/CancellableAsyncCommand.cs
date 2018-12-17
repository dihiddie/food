namespace Icl.Mvvm.Async
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using Nito.Mvvm;

    public class CancellableAsyncCommand : AsyncCommand, ICancellableAsyncCommand
    {
        public CancellableAsyncCommand(
            Func<object, CancellationToken, Task> executeAsync,
            Func<object, ICanExecuteChanged> canExecuteChangedFactory)
            : base(_ => Task.CompletedTask, canExecuteChangedFactory)
            => SetExecutingFunc(CancelCommand.Wrap(executeAsync));

        public CancellableAsyncCommand(Func<object, CancellationToken, Task> executeAsync)
            : base(_ => Task.CompletedTask)
            => SetExecutingFunc(CancelCommand.Wrap(executeAsync));

        public CancellableAsyncCommand(
            Func<CancellationToken, Task> executeAsync,
            Func<object, ICanExecuteChanged> canExecuteChangedFactory)
            : base(() => Task.CompletedTask, canExecuteChangedFactory)
            => SetExecutingFunc(CancelCommand.Wrap(executeAsync));

        public CancellableAsyncCommand(Func<CancellationToken, Task> executeAsync)
            : base(() => Task.CompletedTask)
            => SetExecutingFunc(CancelCommand.Wrap(executeAsync));

        public CancelCommand CancelCommand { get; } = new CancelCommand();

        public void Cancel() => CancelCommand.Cancel();
    }
}
