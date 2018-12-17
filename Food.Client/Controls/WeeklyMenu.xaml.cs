using System.Windows.Controls;
using Food.Client.Interfaces;

namespace Food.Client.Controls
{
    public partial class WeeklyMenu : UserControl, ITabbed
    {
        public WeeklyMenu()
        {
            InitializeComponent();
        }

        public event TabClosed CloseInitiated;

        public string Title => "Недельное меню";

        public string UniqueTabName => "WeeklyMenu";
    }
}
