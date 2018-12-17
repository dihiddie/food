using System.Threading.Tasks;
using System.Windows.Input;

namespace Icl.Mvvm.Async
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}