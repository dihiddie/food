namespace ZAPC.Client.ViewModels.ED301
{
    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Documents.Ed301;

    public class Ed301ViewModel : DocumentViewModel<Ed301>
    {
        public Ed301ViewModel([NotNull] Ed301 model, DocumentMode mode, [CanBeNull] string fileName = null) : base(model, mode, fileName)
        {
        }
    }
}
