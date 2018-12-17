namespace ZAPC.Client.Essentials.Interfaces
{
    using System;
    using System.Threading;
    using System.Threading.Tasks;

    using ZAPC.Client.Essentials.Models;

    public interface IArchiveFileCache
    {
        bool IsEmpty { get; }

        bool ContainsFile(
            DateTime value,
            ArchiveFileType archiveFileType,
            string archiveFileName,
            ArchiveFileStatus archiveFileStatus);

        Task LoadAsync(
            DateTime value,
            ArchiveFileType archiveFileType,
            string archiveFileName,
            ArchiveFileStatus archiveFileStatus,
            CancellationToken cancellationToken);

        Task<byte[]> GetFileBytesAsync(
            DateTime value,
            ArchiveFileType archiveFileType,
            string archiveFileName,
            ArchiveFileStatus archiveFileStatus,
            CancellationToken cancellationToken);

        Task CleanAsync();
    }
}