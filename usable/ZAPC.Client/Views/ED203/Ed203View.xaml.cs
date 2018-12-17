using System.Windows;

namespace ZAPC.Client.Views.ED203
{
    using JetBrains.Annotations;

    using ZAPC.Client.ViewModels.ED203;

    /// <summary>
    /// Interaction logic for Ed203.xaml
    /// </summary>
    public partial class Ed203View : Window
    {
        public Ed203View([NotNull] Ed203ViewModel dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
    }
}
