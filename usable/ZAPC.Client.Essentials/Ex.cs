using System.Windows;

namespace ZAPC.Client.Essentials
{
    public class Ex : DependencyObject
    {
        public static readonly DependencyProperty CustomWidthProperty = DependencyProperty.RegisterAttached(
            "CustomWidth",
            typeof(double),
            typeof(Ex),
            new PropertyMetadata((double)0));

        public static double GetCustomWidth(DependencyObject d) =>
            (double)d.GetValue(CustomWidthProperty);

        public static void SetCustomWidth(
            DependencyObject d, double value)
        {
            d.SetValue(CustomWidthProperty, value);
        }
    }
}
