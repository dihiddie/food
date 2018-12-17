using Food.Common;
using System;
using System.ComponentModel;
using System.Windows.Input;
using System.Windows.Controls;
using Food.Client.Essentials.RelayCommand;

namespace Food.Dashboard.ViewModel
{
    public class DashboardViewModel : ITabbed, INotifyPropertyChanged
    {
        public string Title => "Доска";

        public string UniqueTabName => "DashboardControl";

        public event delClosed CloseInitiated;
        public event PropertyChangedEventHandler PropertyChanged;
        public ICommand  CloseCommand { get; set; }

        public UserControl Control
        {
            get;set;
        }

        public DashboardViewModel(UserControl thisControl)
        {
            Control = thisControl;
            CloseCommand = new RelayCommand(Close);
        }

        private void Close()
        {
            CloseInitiated(this, new EventArgs());
        }
    }
}
