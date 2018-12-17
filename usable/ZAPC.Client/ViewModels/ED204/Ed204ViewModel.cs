using ZAPC.Documents.Ed204;

namespace ZAPC.Client.ViewModels.ED204
{
    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;

    public sealed class Ed204ViewModel : DocumentViewModel<Ed204>
    {
        public Ed204ViewModel([NotNull] Ed204 model, DocumentMode mode, [CanBeNull] string fileName = null) : base(model, mode, fileName)
        {
        }
    }
}
