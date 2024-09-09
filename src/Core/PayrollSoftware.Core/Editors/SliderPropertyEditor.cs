using HandyControl.Controls;
using System.Windows;
using System.Windows.Controls;

namespace PayrollSoftware.Core.Editors
{
    public class SliderPropertyEditor : PropertyEditorBase
    {
        public override FrameworkElement CreateElement(PropertyItem propertyItem)
        {
            var slider = new Slider()
            {
                Margin = new Thickness(10),
                VerticalAlignment = VerticalAlignment.Stretch,
                HorizontalAlignment = HorizontalAlignment.Stretch,
                Maximum = propertyItem.MaxValue,
                Minimum = propertyItem.MinValue,
            };
            TipElement.SetStringFormat(slider, "#0.00");
            TipElement.SetPlacement(slider, HandyControl.Data.PlacementType.Top);
            TipElement.SetVisibility(slider, Visibility.Visible);
            return slider;
        }

        public override DependencyProperty GetDependencyProperty() => Slider.ValueProperty;
    }
}