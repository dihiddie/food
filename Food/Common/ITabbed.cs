using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Food.Common
{
    public delegate void delClosed(ITabbed sender, EventArgs e);
    public interface ITabbed
    {
        event delClosed CloseInitiated;
        string UniqueTabName { get; }
        string Title { get; }
        UserControl Control { get; set; }
        
    }
}
