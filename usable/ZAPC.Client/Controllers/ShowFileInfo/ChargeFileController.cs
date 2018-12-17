namespace ZAPC.Client.Controllers.ShowFileInfo
{
    using System;
    using System.Text;

    using JetBrains.Annotations;

    using ZAPC.Client.Essentials;
    using ZAPC.Client.ViewModels;
    using ZAPC.Client.ViewModels.ChargeFile;
    using ZAPC.Client.Views.ChargeFile;
    using ZAPC.Documents.Ed101;

    public class ChargeFileController : ICreatorController<Ed101>,
                                        ICheckerController<Ed101>,
                                        IEditorController<Ed101>,
                                        IShowFileInfoController
    {
        [CanBeNull]
        public Ed101 Create(string fileName)
        {
            var chargeFile = new Ed101
                                 {
                                     DepartmentalInfo = { DocDate = DateTime.Now },
                                     EdDate = DateTime.Now,
                                     Encoding = Encoding.UTF8
                                 };

            var fileView = new ChargeFileView(new ChargeFileViewModel(chargeFile, DocumentMode.New, fileName));

            return fileView.ShowDialog() ?? false ? chargeFile : null;
        }

        public void Check([NotNull] Ed101 document)
        {
            ShowChargeFileView(new CheckChargeFileViewModel(document, DocumentMode.Check));
        }

        public void Edit([NotNull] Ed101 document)
        {
            ShowChargeFileView(new ChargeFileViewModel(document, DocumentMode.Edit));
        }

        public void ShowFileInfo(object obj)
        {
            if (!(obj is Ed101 ed101)) return;
            ShowChargeFileView(new ChargeFileViewModel(ed101, DocumentMode.Readonly));
        }

        public void ShowFileInfo(string fileName)
        {
            throw new NotSupportedException();
        }

        private void ShowChargeFileView([NotNull] DocumentViewModel<Ed101> viewModel)
        {
            if (viewModel == null)
                throw new ArgumentNullException(nameof(viewModel));

            new ChargeFileView(viewModel).ShowDialog();
        }
    }
}
