namespace ZAPC.Client.ViewModels
{
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Input;

    using AdvancedDataGridControl.Commands;

    public class TabControlContainerViewModel : ViewModelBase
    {
        public TabControlContainerViewModel()
        {
            InitCommands();
        }

        public ICommand OnTabChangedCommand { get; set; }

        public ICommand TabControlLoadedCommand { get; set; }

        public ICommand TestCommand { get; set; }

        private void InitCommands()
        {
            OnTabChangedCommand = new RelayCommand<object>(TabChanged);
            TabControlLoadedCommand = new RelayCommand<object>(TabControlLoaded);
            TestCommand = new RelayCommand(Test);
        }

        private void Test()
        {
            App.BikWorker.UploadAsync(@"C:\Temp\bik_dc_3287_07032018.zip", CancellationToken.None);
        }

        private void TabChanged(object obj)
        {
            if (!(obj is TabControl tabControl)) return;
            foreach (TabItem tab in tabControl.Items)
            {
                if (!(tab.Content is FrameworkElement fe)) continue;
                if (!(fe.DataContext is ObjectDataProvider dataProvider)) continue;
                if (!(dataProvider.Data is IAutoUpdatable autoUpdatable)) continue;

                if (tab.IsSelected)
                    autoUpdatable.StartAutoUpdate();
                else
                    autoUpdatable.StopAutoUpdate();
            }
        }

        private void TabControlLoaded(object selectedContent)
        {
            if (!(selectedContent is FrameworkElement fe)) return;
            if (!(fe.DataContext is ObjectDataProvider dataProvider)) return;
            if (!(dataProvider.Data is IAutoUpdatable autoUpdatable)) return;

            autoUpdatable.StartAutoUpdate();
        }
    }
}
