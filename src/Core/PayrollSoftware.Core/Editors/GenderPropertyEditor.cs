using HandyControl.Controls;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Mvvms;
using System.Windows;

namespace PayrollSoftware.Core.Editors
{
    internal class GenderPropertyEditor : PropertyEditorBase
    {
        private readonly IAppManager _appManager;

        public GenderPropertyEditor()
        {
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public override FrameworkElement CreateElement(PropertyItem propertyItem)
        {
            var t = propertyItem.DefaultValue;
            var cbx = new ComboBox()
            {
                ItemsSource = _appManager.Genders,
                DisplayMemberPath = "Title",
                SelectedValuePath = "Value"
            };
            return cbx;
        }

        public override DependencyProperty GetDependencyProperty()
        {
            return System.Windows.Controls.Primitives.Selector.SelectedValueProperty;
        }
    }
}