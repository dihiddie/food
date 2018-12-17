using System;
using System.Threading.Tasks;

namespace Icl.Mvvm.Async
{
    using Nito.Mvvm;

    public class CustomAsyncCommand : AsyncCommandBaseExtended
    {
        private readonly Func<object, bool> canExecute;

        public CustomAsyncCommand(
            Func<object, Task> executeAsync,
            Func<object, bool> canExecute,
            Func<object, ICanExecuteChanged> canExecuteChangedFactory)
            : base(executeAsync, canExecuteChangedFactory)
            => this.canExecute = canExecute;

        public CustomAsyncCommand(Func<object, Task> executeAsync, Func<object, bool> canExecute)
            : this(executeAsync, canExecute, CanExecuteChangedFactories.DefaultCanExecuteChangedFactory)
        {
        }

        public CustomAsyncCommand(
            Func<Task> executeAsync,
            Func<bool> canExecute,
            Func<object, ICanExecuteChanged> canExecuteChangedFactory)
            : this(_ => executeAsync(), _ => canExecute(), canExecuteChangedFactory)
        {
        }

        public CustomAsyncCommand(Func<Task> executeAsync, Func<bool> canExecute)
            : this(_ => executeAsync(), _ => canExecute(), CanExecuteChangedFactories.DefaultCanExecuteChangedFactory)
        {
        }

        public new void OnCanExecuteChanged() => base.OnCanExecuteChanged();

        protected override void RaiseCanExecuteChanged()
        {
        }

        protected override bool CanExecute(object parameter) => canExecute(parameter);
    }
}