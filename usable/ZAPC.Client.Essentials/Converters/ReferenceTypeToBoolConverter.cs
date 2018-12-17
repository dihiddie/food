namespace ZAPC.Client.Essentials.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    public class ReferenceTypeToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value != null;

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
