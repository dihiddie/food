using System.Windows;

namespace ZAPC.Client.Views.ED202
{
    using JetBrains.Annotations;

    using ZAPC.Client.ViewModels.ED202;

    /// <summary>
    /// Interaction logic for ED202.xaml
    /// </summary>
    public partial class ED202View : Window
    {
        public ED202View([NotNull] Ed202ViewModel dataContext)
        {
            DataContext = dataContext;
            InitializeComponent();
        }
    }
}
