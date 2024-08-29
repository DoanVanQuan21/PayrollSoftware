using System.Windows;
using System.Windows.Controls;

namespace PayrollSoftware.UI.CustomControls
{
    public class TextInput : Control
    {
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register("Label", typeof(string), typeof(TextInput), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty TextProperty =
                    DependencyProperty.Register("Text", typeof(string), typeof(TextInput), new PropertyMetadata(string.Empty));

        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        static TextInput()
        {
        }
    }
}