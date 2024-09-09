using PayrollSoftware.Core.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace PayrollSoftware.UI.CustomControls
{
    public class ChoosePath : Control
    {
        static ChoosePath()
        {
        }

        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        public string FileFilter
        {
            get { return (string)GetValue(FileFilterProperty); }
            set { SetValue(FileFilterProperty, value); }
        }

        // Using a DependencyProperty as the backing store for FileFilter.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FileFilterProperty =
            DependencyProperty.Register("FileFilter", typeof(string), typeof(ChoosePath), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty PathProperty =
            DependencyProperty.Register("Path", typeof(string), typeof(ChoosePath), new PropertyMetadata(string.Empty));

        public override void OnApplyTemplate()
        {
            var button = this.GetTemplateChild("btn") as Button;
            if (button == null) return;
            button.Click += Button_Click;
            base.OnApplyTemplate();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Path = FileHelper.ChoosePathDialog(FileFilter);
        }
    }
}