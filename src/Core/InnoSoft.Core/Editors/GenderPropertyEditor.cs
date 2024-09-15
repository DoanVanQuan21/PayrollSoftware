using HandyControl.Controls;
using InnoSoft.Core.Contracts;
using InnoSoft.Core.Mvvms;
using System.Windows;

namespace InnoSoft.Core.Editors
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