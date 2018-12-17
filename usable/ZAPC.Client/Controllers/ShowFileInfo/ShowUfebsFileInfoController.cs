using System;

using ZAPC.Client.Essentials;
using ZAPC.Client.ViewModels.UfebsFile;
using ZAPC.Client.Views.UfebsFile;

namespace ZAPC.Client.Controllers.ShowFileInfo
{
    public class ShowUfebsFileInfoController : IShowFileInfoController
    {
        public void ShowFileInfo(string fileName)
        {
            UfebsFileView view = new UfebsFileView { DataContext = new UfebsFileViewModel(fileName) };
            view.ShowDialog();
            Container.ServerObject.UnlockUfebsFileAsync(fileName);
        }

        public void ShowFileInfo(object obj)
        {
            throw new NotSupportedException();
        }
    }
}
