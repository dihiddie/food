using System.Windows.Input;
using Food.Client.Essentials.RelayCommand;

namespace Food.Menu.ViewModel
{
    public class MenuViewModel
    {
        public ICommand OpenDashboardCommand { get; set; }
        public MenuViewModel()
        {
            OpenDashboardCommand = new RelayCommand(OpenDashboard);
        }

        private void OpenDashboard()
        {
            Dashboard.View.Dashboard dashboardControl = new Dashboard.View.Dashboard();

        }
    }
}
