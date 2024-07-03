using HandyControl.Controls;
using Management.Core.Contracts;
using Management.Core.Mvvms;
using System.Windows;

namespace Management.Core.Editors
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
            return ComboBox.SelectedValueProperty;
        }
    }
}