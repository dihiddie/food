namespace ZAPC.Client.ViewModels.ED210
{
    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Documents.Ed210;

    public sealed class Ed210ViewModel : DocumentViewModel<Ed210>
    {
        public Ed210ViewModel([NotNull] Ed210 model, DocumentMode mode, [CanBeNull] string fileName = null) : base(model, mode, fileName)
        {
        }
    }
}
