using HandyControl.Controls;
using System.IO.Ports;
using System.Windows;

namespace Management.Core.Editors
{
    internal class BaudratePropertyEditor : PropertyEditorBase
    {
        public override FrameworkElement CreateElement(PropertyItem propertyItem)
        {
            var baudrates = new List<int>() {
                110, 300, 600, 1200, 2400, 4800, 9600, 14400, 19200, 38400, 57600, 115200, 128000, 256000
            };
            var cbx = new ComboBox()
            {
                ItemsSource = baudrates,
            };
            return cbx;
        }

       

        public override DependencyProperty GetDependencyProperty()
        {
            return ComboBox.SelectedValueProperty;
        }
    }
}