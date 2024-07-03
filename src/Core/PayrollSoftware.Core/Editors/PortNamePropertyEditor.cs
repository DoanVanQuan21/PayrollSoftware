using HandyControl.Controls;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Mvvms;
using System.IO.Ports;
using System.Windows;

namespace PayrollSoftware.Core.Editors
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
            return System.Windows.Controls.Primitives.Selector.SelectedValueProperty;
        }
    }
}