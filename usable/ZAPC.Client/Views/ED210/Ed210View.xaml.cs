using System.Windows;

namespace ZAPC.Client.Views.ED210
{
    using JetBrains.Annotations;

    using ZAPC.Client.ViewModels.ED210;

    /// <summary>
    /// Interaction logic for Ed210View.xaml
    /// </summary>
    public partial class Ed210View : Window
    {
        public Ed210View([NotNull] Ed210ViewModel dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
    }
}
