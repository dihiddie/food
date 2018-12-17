using System.Windows;

namespace ZAPC.Client.Views.ContainerPassword
{
    using System;
    using System.Windows.Data;

    using ZAPC.Client.ViewModels.CryptoProInitialization;

    /// <summary>
    /// Interaction logic for ContainerPasswordView.xaml
    /// </summary>
    public partial class ContainerPasswordView : Window
    {
        public ContainerPasswordView()
        {
            InitializeComponent();
        }

        private void ContainerPasswordView_OnInitialized(object sender, EventArgs e)
        {
            ((DataContext as ObjectDataProvider)?.Data as CryptoProInitializationViewModel)?.GetContainerNameCommand
                .Execute(this);
        }
    }
}
