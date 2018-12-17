using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using IconicButtonControl.ActionTypes;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using IconicButtonControl.Annotations;
using IconicButtonControl.Resources;

namespace IconicButtonControl
{
    public class IconicButton : Button, INotifyPropertyChanged
    {
        static IconicButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(IconicButton), new FrameworkPropertyMetadata(typeof(IconicButton)));
        }

        public IconicButton() => Loaded += OnLoaded;

        public ActionType ActionType { get; set; }

        public BitmapImage ImageSource { get; set; }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            //Image image = new Image
            //{
            //    Source = new BitmapImage(
            //      // new Uri($"pack://application:,,,/IconicButtonControl;component/{GetIconPath()}"))
            //    new Uri($"C:\\Users\\User\\Desktop\\Staff\\Food\\CustomControl\\IconicButtonControl\\{GetIconPath()}"))
            //};
            //ImageSource = image;
            // Content = image;
        }
        private void OnLoaded(object sender, RoutedEventArgs routedEventArgs)
        {
            Image image = new Image
            {
                Source = new BitmapImage(
                    // new Uri($"pack://application:,,,/IconicButtonControl;component/{GetIconPath()}"))
                    new Uri($"C:\\Users\\User\\Desktop\\Staff\\Food\\CustomControl\\IconicButtonControl\\{GetIconPath()}"))
            };
            ImageSource = new BitmapImage(
                // new Uri($"pack://application:,,,/IconicButtonControl;component/{GetIconPath()}"))
                // new Uri($"C:\\Users\\User\\Desktop\\Staff\\Food\\CustomControl\\IconicButtonControl\\{GetIconPath()}"));
                new Uri(
                    "C:\\Users\\User\\Desktop\\Staff\\Food\\CustomControl\\IconicButtonControl\\Icons\\delete.png"));
        }

        private string GetIconPath()
        {
            switch (ActionType)
            {
                case ActionType.Add:
                    return IconResources.AddIconFilePath;
                case ActionType.Edit:
                    return IconResources.EditIconFilePath;
                case ActionType.Delete:
                    return IconResources.DeleteIconFilePath;
                case ActionType.ShowDescription:
                    return IconResources.DescriptionIconFilePath;
                default:
                    return string.Empty;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
