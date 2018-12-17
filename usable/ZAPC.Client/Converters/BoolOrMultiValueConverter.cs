using System;

namespace ZAPC.Client.Converters
{
    using System.Globalization;
    using System.Windows.Data;

    using JetBrains.Annotations;

    public class BoolOrMultiValueConverter : IMultiValueConverter
    {
        public object Convert([CanBeNull] object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) return false;

            var res = false;
            foreach (var val in values)
                if (val is bool logicalVal)
                    res |= logicalVal;

            return res;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
