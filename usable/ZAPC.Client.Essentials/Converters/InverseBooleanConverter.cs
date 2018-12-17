namespace ZAPC.Client.Essentials.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using JetBrains.Annotations;

    public class InverseBooleanConverter : IValueConverter
    {
        public object Convert(object value, [NotNull] Type targetType, object parameter, CultureInfo culture)
        {
           if (targetType != typeof(bool))
                throw new InvalidOperationException("The target must be a boolean");

            return !(bool?)value == true;
        }

        public object ConvertBack(object value, [NotNull] Type targetType, object parameter, CultureInfo culture) =>
            Convert(value, targetType, parameter, culture);
    }
}
