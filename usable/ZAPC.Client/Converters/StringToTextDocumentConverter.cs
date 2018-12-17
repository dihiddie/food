using System;
using System.Globalization;
using System.Windows.Data;

using ICSharpCode.AvalonEdit.Document;

namespace ZAPC.Client.Converters
{
    public class StringToTextDocumentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType != typeof(TextDocument))
                throw new InvalidOperationException("The target must be a TextDocument");

            return value == null ? new TextDocument() : new TextDocument((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
