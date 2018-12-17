using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ClosableTabItemControl
{
    public class ClosableTabItem : TabItem
    {
        public static readonly DependencyProperty CloseTabItemCommandProperty = DependencyProperty.Register(
            nameof(CloseTabItemCommand),
            typeof(ICommand),
            typeof(ClosableTabItem));

        public ICommand CloseTabItemCommand
        {
            get => (ICommand)GetValue(CloseTabItemCommandProperty);
            set => SetValue(CloseTabItemCommandProperty, value);
        }

        static ClosableTabItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ClosableTabItem), new FrameworkPropertyMetadata(typeof(ClosableTabItem)));
        }
    }
}
