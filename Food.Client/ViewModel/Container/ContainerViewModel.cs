using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Input;
using ClosableTabItemControl;
using Food.Client.Controllers;
using Food.Client.Essentials.RelayCommand;
using Food.Client.Interfaces;

namespace Food.Client.ViewModel.Container
{
    public class ContainerViewModel : ViewModelBase
    {
        private readonly Dictionary<string, string> childrens = new Dictionary<string, string>();
        private ClosableTabItem selectedItem;

        public ContainerViewModel(ICreateMenuItemController controller)
        {
            Initialize();
            InitializeOpenTabCommands(controller);
        }

        public ICommand OpenDashboardCommand { get; set; }

        public ICommand OpenWeeklyMenuCommand { get; set; }

        public ObservableCollection<TabItem> SomeItemSource { get; set; }

        public ClosableTabItem SelectedItem
        {
            get => selectedItem;

            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        private void Initialize()
        {
            SomeItemSource = new ObservableCollection<TabItem>();
        }

        private void InitializeOpenTabCommands(ICreateMenuItemController controller)
        {
            OpenDashboardCommand = new RelayCommand(() => AddTab(controller.CreateDashboardControl()));
            OpenWeeklyMenuCommand = new RelayCommand(() => AddTab(controller.CreateWeeklyMenuControl()));
        }

        private void AddTab(ITabbed tab)
        {
            if (childrens.ContainsKey(tab.UniqueTabName))
                foreach (var tabItem in SomeItemSource)
                {
                    var item = (ClosableTabItem) tabItem;
                    ClosableTabItem ti = item;
                    if (ti.Name != tab.UniqueTabName) continue;
                    ti.Focus();
                    break;
                }
            else
            {
                tab.CloseInitiated += CloseTab;
                ClosableTabItem ti = new ClosableTabItem
                {
                    Name = tab.UniqueTabName,
                    Header = tab.Title,
                    Content = tab,
                    FontSize = 16,
                    Height = 35,
                    CloseTabItemCommand = new RelayCommand(() => CloseTab(tab, EventArgs.Empty))
                };
                SomeItemSource.Add(ti);
                SelectedItem = ti;
                childrens.Add(tab.UniqueTabName, tab.Title);
            }
        }

        private void CloseTab(ITabbed tab, EventArgs e)
        {
            ClosableTabItem ti = null;
            foreach (var tabItem in SomeItemSource)
            {
                var item = (ClosableTabItem) tabItem;
                if (tab.UniqueTabName != ((ITabbed) item.Content).UniqueTabName) continue;
                ti = item;
                break;
            }

            if (ti == null) return;
            childrens.Remove(((ITabbed)ti.Content).UniqueTabName);
            SomeItemSource.Remove(ti);
        }
    }
}
