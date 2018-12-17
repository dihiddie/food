using System.Windows.Input;
using ZAPC.Client.Controllers.ShowDocument;
using ZAPC.Client.Essentials.Commands;

namespace ZAPC.Client.ViewModels
{
    public class ShowDocumentsViewModel
    {
        public ShowDocumentsViewModel(IShowDocumentsController controller) =>
            ShowListOfEd101Command = new RelayCommand(controller.ShowListOfEd101);

        public ICommand ShowListOfEd101Command { get; set; }
    }
}
