using System.Windows;

namespace ZAPC.Client.Views.SelectEDAuthor
{
    using ZAPC.Client.ViewModels.SelectEDAuthor;

    /// <summary>
    /// Interaction logic for SelectEDAuthorView.xaml
    /// </summary>
    public partial class SelectEdAuthorView : Window
    {
        public SelectEdAuthorView()
        {
            InitializeComponent();

            DataContext = new SelectEdAuthorViewModel(this);
        }
    }
}
