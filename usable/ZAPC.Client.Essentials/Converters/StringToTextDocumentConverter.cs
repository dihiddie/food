namespace ZAPC.Client.Essentials.Converters
{
    using System;
    using System.Globalization;
    using System.Windows.Data;

    using ICSharpCode.AvalonEdit.Document;

    using JetBrains.Annotations;

    public class StringToTextDocumentConverter : IValueConverter
    {
        [NotNull]
        public object Convert(object value, [NotNull] Type targetType, object parameter, CultureInfo culture)
        {
            if (targetType == null) throw new ArgumentNullException(nameof(targetType));

            if (targetType != typeof(TextDocument))
                throw new InvalidOperationException("The target must be a TextDocument");

            return value == null ? new TextDocument() : new TextDocument((string)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) =>
            throw new NotSupportedException();
    }
}
