namespace ZAPC.Client.ViewModels.ChargeFile
{
    using System.Threading;
    using System.Threading.Tasks;

    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Documents.Ed101;

    public class ChargeFileViewModel : DocumentViewModel<Ed101>
    {
        public ChargeFileViewModel([NotNull] Ed101 model, DocumentMode mode, [CanBeNull] string fileName = null)
            : base(model, mode, fileName)
        {
        }

        protected override async Task SendDocumentToServerAsync(CancellationToken token)
        {
            if (!Model.IsValid()) return;
            await Container.ServerObject.SendChargeFileAsync(Model.FileName, Model.Encoding.GetBytes(Model.XmlContent), token).ConfigureAwait(false);
        }
    }
}
