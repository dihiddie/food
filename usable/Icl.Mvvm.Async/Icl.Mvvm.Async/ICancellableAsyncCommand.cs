namespace Icl.Mvvm.Async
{
    public interface ICancellableAsyncCommand : IAsyncCommand
    {
        CancelCommand CancelCommand { get; }

        void Cancel();
    }
}
