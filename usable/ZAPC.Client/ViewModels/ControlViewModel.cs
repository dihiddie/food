using System.Windows;
using System.Windows.Input;
using ZAPC.Client.Essentials.Commands;

namespace ZAPC.Client.ViewModels
{
    public class ControlViewModel
    {
        public ControlViewModel() => InitializeCommands();

        public ICommand CloseWindowCommand { get; set; }

        public ICommand CloseWithDialogResultTrueCommand { get; set; }

        public ICommand CloseWithDialogResultFalseCommand { get; set; }

        private static void CloseWindow(Window win) => win.Close();

        private static void CloseWithDialogResultTrue(Window win) => CloseWithDialogResult(win, true);

        private static void CloseWithDialogResultFalse(Window win) => CloseWithDialogResult(win, false);

        private static void CloseWithDialogResult(Window win, bool dialogResult)
        {
            win.DialogResult = dialogResult;
            win.Close();
        }

        private void InitializeCommands()
        {
            CloseWindowCommand = new RelayCommand<Window>(CloseWindow);
            CloseWithDialogResultTrueCommand = new RelayCommand<Window>(CloseWithDialogResultTrue);
            CloseWithDialogResultFalseCommand = new RelayCommand<Window>(CloseWithDialogResultFalse);
        }
    }
}
