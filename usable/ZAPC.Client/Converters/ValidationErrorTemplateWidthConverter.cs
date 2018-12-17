using System;

namespace ZAPC.Client.Converters
{
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;

    using JetBrains.Annotations;

    public class ValidationErrorTemplateWidthConverter : IMultiValueConverter
    {
        [NotNull]
        public object Convert(
            [NotNull] object[] values,
            Type targetType,
            [CanBeNull] object parameter,
            CultureInfo culture)
        {
            if (values.Length < 2)
                throw new ArgumentException(@"Not enough arguments", nameof(values));

            var tag = values[0]; // Value or Null
            var width = (double)(values[1] == DependencyProperty.UnsetValue ? 0.0 : values[1]);
            var text = values.Length > 2
                           ? values[2]?.ToString()
                           : null; // For Textbox => Text else null; For CheckBox => SelectedItem
            var hasErrors = parameter; // True or Null
            /*
            if (tag != null || (!string.IsNullOrEmpty(text) && hasErrors != null))
                width = width - 29;
            */

            return width;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) =>
            throw new NotImplementedException();
    }
}
