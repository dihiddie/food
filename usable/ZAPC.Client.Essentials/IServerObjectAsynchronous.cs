using System.Threading;

namespace ZAPC.Client.Essentials
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Text;
    using System.Threading.Tasks;

    using ZAPC.Client.Essentials.Models;
    using ZAPC.Documents;
    using ZAPC.Documents.Ed101;

    public interface IServerObjectAsynchronous
    {
        Task<IEnumerable<string>> GetUfebsFilesAsync(CancellationToken cancellationToken);

        Task<IEnumerable<Ed101>> GetChargeFilesAsync(CancellationToken cancellationToken);

        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:ClosingParenthesisMustBeSpacedCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        Task<(Encoding Encoding, string content)> GetFileContentAsync(string fileName, CancellationToken cancellationToken);

        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:ClosingParenthesisMustBeSpacedCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        Task<(Encoding Encoding, string content)> GetChargeFileContentAsync(string fileName, CancellationToken cancellationToken);

        [SuppressMessage("StyleCop.CSharp.SpacingRules", "SA1009:ClosingParenthesisMustBeSpacedCorrectly", Justification = "Reviewed. Suppression is OK here.")]
        Task<(Encoding Encoding, string content)> GetOtherDocsContentAsync(string fileName, CancellationToken cancellationToken);

        Task SendSignAsync(string fileName, byte[] sign, CancellationToken cancellationToken);

        Task SendChargeSignAsync(string fileName, byte[] sign, CancellationToken cancellationToken);

        Task SendOtherDocumentSignAsync(string fileName, byte[] sign, CancellationToken cancellationToken);

        Task UnlockUfebsFileAsync(string fileName);

        Task UnlockChargeFileAsync(string fileName);

        Task RemoveChargeFileAsync(string fileName, CancellationToken cancellationToken);

        Task SendChargeFileAsync(string fileName, byte[] content, CancellationToken cancellationToken);

        Task<string> GetDocumentNameAsync(string typeCode, CancellationToken cancellationToken);

        Task<IEnumerable<EdAuthorModel>> GetEdAuthorsAsync(CancellationToken cancellationToken);

        Task SendDocumentFileAsync(string fileName, byte[] content, CancellationToken cancellationToken);

        Task<IEnumerable<PacketEpd>> GetPacketEpdList(CancellationToken cancellationToken);

        Task<IEnumerable<IDocumentWithCreationDateTime>> GetOtherDocsList(CancellationToken cancellationToken);

        Task<ArchiveFilesNamesList> GetArchiveFilesAsync(
            DateTime archiveFilesDate,
            CancellationToken cancellationToken);

        Task<byte[]> GetArchiveFileBytesAsync(
            DateTime archiveFilesDate,
            ArchiveFileType archiveFileType,
            string archiveFileName,
            ArchiveFileStatus archiveFileStatus,
            CancellationToken cancellationToken);

        Task SendBikAsync(BikModel model, CancellationToken cancellationToken);

        Task SendBikDiffAsync(BikDiffModel model, CancellationToken cancellationToken);

        Task<IEnumerable<Bik>> DownloadBiksAsync(CancellationToken cancellationToken);
    }
}
