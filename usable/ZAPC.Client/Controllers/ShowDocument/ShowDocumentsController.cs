namespace ZAPC.Client.Controllers.ShowDocument
{
    using ZAPC.Client.Views.ChargeListOfFiles;

    public class ShowDocumentsController : IShowDocumentsController
    {
        public void ShowListOfEd101()
        {
            ChargeListOfFilesView chargeListView = new ChargeListOfFilesView();
            chargeListView.ShowDialog();
        }
    }
}
