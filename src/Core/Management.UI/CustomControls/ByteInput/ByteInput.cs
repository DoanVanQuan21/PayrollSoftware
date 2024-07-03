using Management.Core.Models.Common;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Management.UI.CustomControls.ByteInput
{
    public class ByteInput : Control
    {
        public static readonly RoutedCommand NextInputCommand = new();
        public static DependencyProperty ItemsSourceProperty = DependencyProperty.Register(nameof(ItemsSource), typeof(ObservableCollection<KeyValue>), typeof(ByteInput), new PropertyMetadata(default));

        public ObservableCollection<KeyValue> ItemsSource
        {
            get => (ObservableCollection<KeyValue>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        public override void OnApplyTemplate()
        {
            CommandBindings.Add(new CommandBinding(NextInputCommand, OnNextInput));
            base.OnApplyTemplate();
        }

        private void OnNextInput(object sender, ExecutedRoutedEventArgs e)
        {
        }
    }
}