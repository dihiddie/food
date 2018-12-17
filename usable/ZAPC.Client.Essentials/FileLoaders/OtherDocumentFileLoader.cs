namespace ZAPC.Client.Essentials.FileLoaders
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using JetBrains.Annotations;
    using ZAPC.Documents;

    public class OtherDocumentFileLoader : IFileLoaderAsynchronous<IDocumentWithCreationDateTime>
    {
        [ItemNotNull]
        public async Task<IEnumerable<IDocumentWithCreationDateTime>> GetFilesAsync(CancellationToken cancellationToken)
            => await Container.ServerObject.GetOtherDocsList(cancellationToken).ConfigureAwait(false);
    }
}
