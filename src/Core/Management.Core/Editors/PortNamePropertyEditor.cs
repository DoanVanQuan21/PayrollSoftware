using HandyControl.Controls;
using Management.Core.Contracts;
using Management.Core.Mvvms;
using System.IO.Ports;
using System.Windows;

namespace Management.Core.Editors
{
    internal class PortNamePropertyEditor : PropertyEditorBase
    {
        private readonly IAppManager _appManager;

        public PortNamePropertyEditor()
        {
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public override FrameworkElement CreateElement(PropertyItem propertyItem)
        {
            var cbx = new ComboBox()
            {
                ItemsSource = SerialPort.GetPortNames(),
            };
            return cbx;
        }

        public override DependencyProperty GetDependencyProperty()
        {
            return ComboBox.SelectedValueProperty;
        }
    }
}