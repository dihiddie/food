using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using Nito.Disposables;

namespace Icl.Mvvm.Async
{
    using Nito.Mvvm;

    public sealed class CancelCommand : ICommand
    {
        private readonly ICanExecuteChanged canExecuteChanged;

        private RefCountedCancellationTokenSource contextField;

        public CancelCommand(Func<object, ICanExecuteChanged> canExecuteChangedFactory) =>
            canExecuteChanged = canExecuteChangedFactory(this);

        public CancelCommand()
            : this(CanExecuteChangedFactories.DefaultCanExecuteChangedFactory)
        {
        }

        event EventHandler ICommand.CanExecuteChanged
        {
            add => canExecuteChanged.CanExecuteChanged += value;
            remove => canExecuteChanged.CanExecuteChanged -= value;
        }

        bool ICommand.CanExecute(object parameter) => contextField != null;

        void ICommand.Execute(object parameter)
        {
            contextField.Cancel();
        }

        public void Cancel() => contextField?.Cancel();

        public Func<object, Task> WrapCancel(Func<object, CancellationToken, Task> executeAsync)
        {
            var wrapped = Wrap(executeAsync);
            return async parameter =>
                {
                    Cancel();
                    await wrapped(parameter).ConfigureAwait(false);
                };
        }

        public Func<Task> WrapCancel(Func<CancellationToken, Task> executeAsync)
        {
            var wrapped = Wrap(executeAsync);
            return async () =>
                {
                    Cancel();
                    await wrapped().ConfigureAwait(false);
                };
        }

        public Func<object, Task> Wrap(Func<object, CancellationToken, Task> executeAsync)
        {
            return async parameter =>
                {
                    using (StartOperation())
                    {
                        try
                        {
                            await executeAsync(parameter, contextField.Token).ConfigureAwait(true);
                        }
                        catch (OperationCanceledException)
                        {
                            // We cannot use `when (ex.CancellationToken == cancellationToken)` on the catch block because the user delegate may be cancelled by a linked CancellationToken.
                        }
                    }
                };
        }

        public Func<Task> Wrap(Func<CancellationToken, Task> executeAsync)
        {
            var wrapped = Wrap((_, token) => executeAsync(token));
            return () => wrapped(null);
        }

        private IDisposable StartOperation()
        {
            if (contextField != null) return contextField.StartOperation();
            contextField = new RefCountedCancellationTokenSource(this);
            canExecuteChanged.OnCanExecuteChanged();
            return contextField.StartOperation();
        }

        private void Notify(RefCountedCancellationTokenSource context)
        {
            if (contextField != context)
                return;
            contextField = null;
            canExecuteChanged.OnCanExecuteChanged();
        }

        private sealed class RefCountedCancellationTokenSource
        {
            private readonly CancelCommand parent;

            private readonly CancellationTokenSource cts = new CancellationTokenSource();

            private int count;

            public RefCountedCancellationTokenSource(CancelCommand parent) => this.parent = parent;

            public CancellationToken Token => cts.Token;

            public IDisposable StartOperation()
            {
                ++count;
                return new AnonymousDisposable(Signal);
            }

            public void Cancel()
            {
                cts.Cancel();
                parent.Notify(this);
            }

            private void Signal()
            {
                if (--count != 0)
                    return;
                Cancel();
            }
        }
    }
}