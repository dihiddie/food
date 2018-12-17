namespace ZAPC.Client.Essentials.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using JetBrains.Annotations;

    public sealed class TitleConverter : IMultiValueConverter
    {
        [NotNull]
        public object Convert([NotNull] object[] values, Type targetType, object parameter, CultureInfo culture) =>
            $"{values[1]} - {values[0]}";

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
