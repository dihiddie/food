using System.Windows;

namespace ZAPC.Client.Views.ED204
{
    using JetBrains.Annotations;

    using ZAPC.Client.ViewModels.ED204;

    /// <summary>
    /// Interaction logic for Ed204View.xaml
    /// </summary>
    public partial class Ed204View : Window
    {
        public Ed204View([NotNull] Ed204ViewModel dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
    }
}
