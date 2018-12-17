using System.Windows;

namespace ZAPC.Client.Views.ED301
{
    using JetBrains.Annotations;

    using ZAPC.Client.ViewModels.ED301;

    /// <summary>
    /// Interaction logic for Ed301View.xaml
    /// </summary>
    public partial class Ed301View : Window
    {
        public Ed301View([NotNull] Ed301ViewModel dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
    }
}
