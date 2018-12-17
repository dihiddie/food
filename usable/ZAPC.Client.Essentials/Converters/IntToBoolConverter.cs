namespace ZAPC.Client.Essentials.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class IntToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => (int?)value > 0;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => throw new NotSupportedException();
    }
}
