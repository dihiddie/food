namespace ZAPC.Client.Essentials
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using ZAPC.Client.Essentials.Models;

    public interface IBikWorker
    {
        void Upload(string filePath);

        Task UploadAsync(string filePath, CancellationToken token);

        IEnumerable<Bik> Download();

        Task<IEnumerable<Bik>> DownloadAsync(CancellationToken token);
    }
}