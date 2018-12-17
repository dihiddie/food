using System.Windows;

namespace ZAPC.Client.Views.ED421
{
    using JetBrains.Annotations;

    using ZAPC.Client.ViewModels.ED421;

    /// <summary>
    /// Interaction logic for Ed421View.xaml
    /// </summary>
    public partial class Ed421View : Window
    {
        public Ed421View([NotNull] Ed421ViewModel dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
    }
}
