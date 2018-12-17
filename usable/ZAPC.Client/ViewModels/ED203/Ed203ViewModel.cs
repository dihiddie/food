namespace ZAPC.Client.ViewModels.ED203
{
    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Documents.Ed203;

    public class Ed203ViewModel : DocumentViewModel<Ed203>
    {
        public Ed203ViewModel([NotNull] Ed203 model, DocumentMode mode, [CanBeNull] string fileName = null) : base(model, mode, fileName)
        {
        }
    }
}
