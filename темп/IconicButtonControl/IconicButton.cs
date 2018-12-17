using System.Windows;
using System.Windows.Controls;
using IconicButtonControl.ActionTypes;

namespace IconicButtonControl
{
    public class IconicButton : Button
    {
        static IconicButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconicButton), new FrameworkPropertyMetadata(typeof(IconicButton)));
        }

        public IconicButton()
        {

        }

        public ActionType ActionType { get; set; }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
    }
}
