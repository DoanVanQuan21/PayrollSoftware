using HandyControl.Controls;
using InnoSoft.Core.Contracts;
using InnoSoft.Core.Mvvms;
using System.IO.Ports;
using System.Windows;

namespace InnoSoft.Core.Editors
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