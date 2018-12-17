using System;
using System.Threading.Tasks;

namespace Icl.Mvvm.Async
{
    using System.ComponentModel;

    using Nito.Mvvm;

    public sealed class NotifyTask<TResult> : INotifyPropertyChanged
    {
        private readonly TResult defaultResult;

        internal NotifyTask(Task<TResult> task, TResult defaultResult)
        {
            this.defaultResult = defaultResult;
            Task = task;
            TaskCompleted = MonitorTaskAsync(task);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Task<TResult> Task { get; }

        public Task TaskCompleted { get; }

        public TResult Result => (Task.Status == TaskStatus.RanToCompletion) ? Task.Result : defaultResult;

        public TaskStatus Status => Task.Status;

        public bool IsCompleted => Task.IsCompleted;

        public bool IsNotCompleted => !Task.IsCompleted;

        public bool IsSuccessfullyCompleted => Task.Status == TaskStatus.RanToCompletion;

        public bool IsCanceled => Task.IsCanceled;

        public bool IsFaulted => Task.IsFaulted;

        public AggregateException Exception => Task.Exception;

        public Exception InnerException => Exception?.InnerException;

        public string ErrorMessage => InnerException?.Message;

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
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("Result"));
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("Status"));
                propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("IsSuccessfullyCompleted"));
            }

            propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("IsCompleted"));
            propertyChanged(this, PropertyChangedEventArgsCache.Instance.Get("IsNotCompleted"));
        }
    }
}
