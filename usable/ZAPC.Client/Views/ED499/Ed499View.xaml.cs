using System.Windows;

namespace ZAPC.Client.Views.ED499
{
    using JetBrains.Annotations;

    using ZAPC.Client.ViewModels.ED499;

    /// <summary>
    /// Interaction logic for Ed499View.xaml
    /// </summary>
    public partial class Ed499View : Window
    {
        public Ed499View([NotNull] Ed499ViewModel dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
    }
}
