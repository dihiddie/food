using System.Windows;
using System.Windows.Controls;

namespace LinedTextBoxControl
{
    public class LinedTextBox : TextBox
    {
        static LinedTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LinedTextBox), new FrameworkPropertyMetadata(typeof(LinedTextBox)));
        }

        public string WatermarkText { get; set; } = "Введите текст";
    }
}
