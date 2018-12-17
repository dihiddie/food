namespace ZAPC.Client.Essentials.ViewModels
{
    using System.Windows;
    using System.Windows.Input;

    using JetBrains.Annotations;

    using ZAPC.Client.Essentials.Commands;

    public class ControlViewModel
    {
        public ControlViewModel() => InitializeCommands();

        public ICommand CloseWindowCommand { get; set; }

        public ICommand CloseWithDialogResultTrueCommand { get; set; }

        public ICommand CloseWithDialogResultFalseCommand { get; set; }

        private static void CloseWindow([NotNull] Window win) => win.Close();

        private static void CloseWithDialogResultTrue([NotNull] Window win) => CloseWithDialogResult(win, true);

        private static void CloseWithDialogResultFalse([NotNull] Window win) => CloseWithDialogResult(win, false);

        private static void CloseWithDialogResult([NotNull] Window win, bool dialogResult)
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
