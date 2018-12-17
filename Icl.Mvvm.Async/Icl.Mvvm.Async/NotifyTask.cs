using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Icl.Mvvm.Async
{
    using Nito.Mvvm;

    public sealed class NotifyTask : INotifyPropertyChanged
    {
        private NotifyTask(Task task)
        {
            Task = task;
            TaskCompleted = MonitorTaskAsync(task);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Task Task { get; }

        public Task TaskCompleted { get; }

        public TaskStatus Status => Task.Status;

        public bool IsCompleted => Task.IsCompleted;

        public bool IsNotCompleted => !Task.IsCompleted;

        public bool IsSuccessfullyCompleted => Task.Status == TaskStatus.RanToCompletion;

        public bool IsCanceled => Task.IsCanceled;

        public bool IsFaulted => Task.IsFaulted;

        public AggregateException Exception => Task.Exception;

        public Exception InnerException => Exception?.InnerException;

        public string ErrorMessage => InnerException?.Message;

        public static NotifyTask Create(Task task) => new NotifyTask(task);

        public static NotifyTask<TResult>
            Create<TResult>(Task<TResult> task, TResult defaultResult = default(TResult)) =>
            new NotifyTask<TResult>(task, defaultResult);

        public static NotifyTask Create(Func<Task> asyncAction) => Create(asyncAction());

        public static NotifyTask<TResult> Create<TResult>(
            Func<Task<TResult>> asyncAction,
            TResult defaultResult = default(TResult)) =>
            Create(asyncAction(), defaultResult);

        private async Task MonitorTaskAsync(Task task)
        {
            try
            {
                await task.ConfigureAwait(true);
            }
            catch
            {
                // ignored
            }
            finally
            {
                NotifyProperties(task);
            }
        }

        private void NotifyProperties(Task task)
        {
            var propertyChanged = PropertyChanged;
            if (propertyChanged == null)
                return;

            if (task.IsCanceled)
            {
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("Status"));
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("IsCanceled"));
            }
            else if (task.IsFaulted)
            {
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("Exception"));
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("InnerException"));
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("ErrorMessage"));
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("Status"));
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("IsFaulted"));
            }
            else
            {
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("Status"));
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("IsSuccessfullyCompleted"));
            }

            propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("IsCompleted"));
            propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("IsNotCompleted"));
        }
    }
}
