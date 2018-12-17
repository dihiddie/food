namespace ZAPC.Client.ViewModels.ListOfFiles
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Windows.Threading;

    using JetBrains.Annotations;

    using ZAPC.Client.Controllers.ShowFileInfo;
    using ZAPC.Client.Essentials;
    using ZAPC.Client.Essentials.Models;
    using ZAPC.Documents.Interfaces;
    using ZAPC.Documents.Statuses.DocumentActions.Interfaces;

    public sealed class ListOfFilesOfPacketEpdViewModel : ListOfDocumentsViewModel<PacketEpd>, IOpenDocAction
    {
        public ListOfFilesOfPacketEpdViewModel(
            IFileLoaderAsynchronous<PacketEpd> fileLoader,
            IShowFileInfoController controller)
            : base(fileLoader, controller)
        {
        }

        [NotNull]
        public async Task OpenAsync(object edObject, CancellationToken cancellationToken)
        {
            StopAutoUpdate();
            await OpenFileByFileNameAsync(((IFileNameContainer)edObject).FileName, cancellationToken)
                .ConfigureAwait(true);
            StartAutoUpdate();
        }

        [NotNull]
        public override Task RemoveAsync(string fileName, CancellationToken token) => Task.CompletedTask;

        // ReSharper disable once StyleCop.SA1009
        protected override async Task<(Encoding, string)> GetContentAsync(
            [CanBeNull] IFileNameContainer obj,
            CancellationToken token)
        {
            var(encoding, content) =
                await Container.ServerObject.GetFileContentAsync(obj?.FileName, token).ConfigureAwait(false);
            Task unused = Container.ServerObject.UnlockUfebsFileAsync(obj?.FileName);
            return (encoding, content);
        }

        protected override Task SendSignAsync(string fileName, byte[] signData, CancellationToken token) =>
            Container.ServerObject.SendSignAsync(fileName, signData, token);

        protected override void SetFilters()
        {
        }

        [NotNull]
        protected override Task RemoveElementsFromSourceAndFile(IDictionary<string, PacketEpd> dataFromServer, Dispatcher dispatcher, CancellationToken cancellationToken)
             => Task.Run(
                () =>
                    {
                        var dataToRemove = SourceCollection.Keys.Where(x => !dataFromServer.Keys.Contains(x)).ToList();
                        foreach (var row in dataToRemove)
                        {
                            SourceCollection.TryRemove(row, out var val);
                            dispatcher.Invoke(() => RemoveFromFilesCollection(val));
                        }
                    },
                cancellationToken);

        [NotNull]
        protected override Task<Dictionary<string, PacketEpd>> GetElementsToBeAddedOrUpdated(IDictionary<string, PacketEpd> dataFromServer, CancellationToken cancellationToken)
            => Task.Run(() => dataFromServer.Where(x => !SourceCollection.Keys.Contains(x.Key)).ToDictionary(x => x.Key, pair => pair.Value), cancellationToken);

        [NotNull]
        protected override Task AddOrUpdateSourceColletion(IDictionary<string, PacketEpd> elementsToBeAddedOrUpdated, CancellationToken cancellationToken)
            => Task.Run(() => { foreach (var elem in elementsToBeAddedOrUpdated) SourceCollection.TryAdd(elem.Key, elem.Value); }, cancellationToken);
    }
}
