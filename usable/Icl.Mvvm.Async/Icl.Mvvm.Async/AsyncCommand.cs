using System;
using System.Threading.Tasks;

namespace Icl.Mvvm.Async
{
    using Nito.Mvvm;

    public class AsyncCommand : AsyncCommandBaseExtended
    {
        public AsyncCommand(Func<object, Task> executeAsync, Func<object, ICanExecuteChanged> canExecuteChangedFactory)
            : base(executeAsync, canExecuteChangedFactory)
        {
        }

        public AsyncCommand(Func<object, Task> executeAsync)
            : this(executeAsync, CanExecuteChangedFactories.DefaultCanExecuteChangedFactory)
        {
        }

        public AsyncCommand(Func<Task> executeAsync, Func<object, ICanExecuteChanged> canExecuteChangedFactory)
            : this(_ => executeAsync(), canExecuteChangedFactory)
        {
        }

        public AsyncCommand(Func<Task> executeAsync)
            : this(_ => executeAsync(), CanExecuteChangedFactories.DefaultCanExecuteChangedFactory)
        {
        }

        protected override void RaiseCanExecuteChanged() => OnCanExecuteChanged();

        protected override bool CanExecute(object parameter) => !IsExecuting;
    }
}