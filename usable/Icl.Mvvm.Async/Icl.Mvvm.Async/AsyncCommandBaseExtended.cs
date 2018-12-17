namespace Icl.Mvvm.Async
{
    using System;
    using System.ComponentModel;
    using System.Threading;
    using System.Threading.Tasks;

    using Nito.Mvvm;

    public abstract class AsyncCommandBaseExtended : AsyncCommandBase, INotifyPropertyChanged
    {
        private Func<object, Task> executeAsyncField;

        protected AsyncCommandBaseExtended(Func<object, Task> executeAsync, Func<object, ICanExecuteChanged> canExecuteChangedFactory)
            : base(canExecuteChangedFactory)
            => executeAsyncField = executeAsync;

        public event PropertyChangedEventHandler PropertyChanged;

        public NotifyTask Execution { get; private set; }

        public bool IsExecuting => Execution?.IsNotCompleted == true;

        public void SetExecutingFunc(Func<object, Task> executeAsync) => executeAsyncField = executeAsync;

        public void SetExecutingFunc(Func<Task> executeAsync) => executeAsyncField = _ => executeAsync();

        public override async Task ExecuteAsync(object parameter)
        {
            var tcs = new TaskCompletionSource<object>();
            Execution = NotifyTask.Create(DoExecuteAsync(tcs.Task, executeAsyncField, parameter));
            RaiseCanExecuteChanged();
            OnPropertyChanged("Execution");
            OnPropertyChanged("IsExecuting");
            tcs.SetResult(null);
            await Execution.TaskCompleted.ConfigureAwait(true);
            RaiseCanExecuteChanged();
            OnPropertyChanged("IsExecuting");
            await Execution.Task.ConfigureAwait(true);
        }

        protected abstract void RaiseCanExecuteChanged();

        protected void OnPropertyChanged(string propName)
        {
            Volatile.Read(ref PropertyChanged)?.Invoke(this, PropertyChangedEventArgsCache.Instance.Get(propName));
        }

        private static async Task DoExecuteAsync(Task precondition, Func<object, Task> executeAsync, object parameter)
        {
            await precondition.ConfigureAwait(true);
            await executeAsync(parameter).ConfigureAwait(true);
        }
    }
}
