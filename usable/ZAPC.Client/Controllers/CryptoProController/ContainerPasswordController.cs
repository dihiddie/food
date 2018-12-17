namespace ZAPC.Client.Controllers.CryptoProController
{
    using System.Windows;

    using ZAPC.Client.Views.SelectEDAuthor;

    public class ContainerPasswordController : ICryptoProController
    {
        public void SuccessInitialization(object sender)
        {
            var selectEdAuthorView = new SelectEdAuthorView();
            selectEdAuthorView.Show();

            CloseWindow(sender);
        }

        public void InitializationFailed(object sender) => CloseWindow(sender);

        private static void CloseWindow(object obj)
        {
            if (obj is Window window) window.Close();
        }
    }
}
