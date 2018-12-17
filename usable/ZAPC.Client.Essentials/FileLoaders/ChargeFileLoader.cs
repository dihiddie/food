namespace ZAPC.Client.Essentials.FileLoaders
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    using ZAPC.Documents.Ed101;

    public sealed class ChargeFileLoader : IFileLoaderAsynchronous<Ed101>
    {
        [ItemNotNull]
        public Task<IEnumerable<Ed101>> GetFilesAsync(CancellationToken cancellationToken) =>
            Container.ServerObject.GetChargeFilesAsync(cancellationToken);
    }
}
