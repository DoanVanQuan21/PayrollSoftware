using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Task = PayrollSoftware.Core.Models.TaskManagement.Task;
namespace PayrollSoftware.TaskManagement.CustomControls
{
    public class Tasks : Control
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(Tasks), new PropertyMetadata(null));

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(Tasks), new PropertyMetadata(false));

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<Task>), typeof(Tasks), new PropertyMetadata(null, OnItemsSourcePropertyChanged, CoerceItemsSourceValue));

        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof(string), typeof(Tasks), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SelectedTaskProperty =
                    DependencyProperty.Register("SelectedTask", typeof(Task), typeof(Tasks), new PropertyMetadata(null));

        public static readonly DependencyProperty TitleProperty =
                                    DependencyProperty.Register("Title", typeof(string), typeof(Tasks), new PropertyMetadata(string.Empty));

        static Tasks()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Tasks), new FrameworkPropertyMetadata(typeof(Tasks)));
        }

        public Geometry Icon
        {
            get { return (Geometry)GetValue(IconProperty); }
            set { SetValue(IconProperty, value); }
        }

        public bool IsActive
        {
            get { return (bool)GetValue(IsActiveProperty); }
            set { SetValue(IsActiveProperty, value); }
        }

        public ObservableCollection<Task> ItemsSource
        {
            get { return (ObservableCollection<Task>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public string Key
        {
            get { return (string)GetValue(KeyProperty); }
            set { SetValue(KeyProperty, value); }
        }

        public Task SelectedTask
        {
            get { return (Task)GetValue(SelectedTaskProperty); }
            set { SetValue(SelectedTaskProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }

        private static object CoerceItemsSourceValue(DependencyObject d, object baseValue)
        {
            var control = (Tasks)d;
            if (control?.ItemsSource != null)
            {
                //TODO
            }
            return baseValue;
        }

        private static void OnItemsSourcePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = (Tasks)d;
            if (control?.ItemsSource != null)
            {
                control.OnItemsSourceChanged((IEnumerable)e.OldValue, (IEnumerable)e.NewValue);
            }
        }

        private void ItemsSource_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
        }

        private void NewValueINotifyCollectionChanged_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
        }

        private void OnItemsSourceChanged(IEnumerable oldValue, IEnumerable newValue)
        {
            // Remove handler for oldValue.CollectionChanged

            if (oldValue is INotifyCollectionChanged oldValueINotifyCollectionChanged)
            {
                oldValueINotifyCollectionChanged.CollectionChanged -= new NotifyCollectionChangedEventHandler(NewValueINotifyCollectionChanged_CollectionChanged);
            }

            // Add handler for newValue.CollectionChanged (if possible)
            if (newValue is INotifyCollectionChanged newValueINotifyCollectionChanged)
            {
                newValueINotifyCollectionChanged.CollectionChanged += new NotifyCollectionChangedEventHandler(NewValueINotifyCollectionChanged_CollectionChanged);
            }
        }
    }
}