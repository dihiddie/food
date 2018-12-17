namespace ZAPC.Client.Essentials
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public interface IFileLoaderAsynchronous<T>
    {
        Task<IEnumerable<T>> GetFilesAsync(CancellationToken cancellationToken);
    }
}
