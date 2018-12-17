using System.Windows.Controls;
using Food.Client.Interfaces;

namespace Food.Client.Controls
{
    /// <summary>
    /// Interaction logic for Dashboard.xaml
    /// </summary>
    public partial class Dashboard : UserControl, ITabbed
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        public string UniqueTabName => "Dashboard";

        public string Title => "Доска";

        public event TabClosed CloseInitiated;
    }
}
