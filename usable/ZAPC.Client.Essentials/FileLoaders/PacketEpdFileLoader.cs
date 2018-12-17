namespace ZAPC.Client.Essentials.FileLoaders
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    using ZAPC.Client.Essentials.Models;

    public sealed class PacketEpdFileLoader : IFileLoaderAsynchronous<PacketEpd>
    {
        public async Task<IEnumerable<PacketEpd>> GetFilesAsync(CancellationToken cancellationToken)
            => await Container.ServerObject.GetPacketEpdList(cancellationToken).ConfigureAwait(false);
    }
}
