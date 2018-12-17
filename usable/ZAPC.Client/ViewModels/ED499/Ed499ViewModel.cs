namespace ZAPC.Client.ViewModels.ED499
{
    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Documents.Ed499;

    public sealed class Ed499ViewModel : DocumentViewModel<Ed499>
    {
        public Ed499ViewModel([NotNull] Ed499 model, DocumentMode mode, [CanBeNull] string fileName = null) : base(model, mode, fileName)
        {
        }
    }
}
