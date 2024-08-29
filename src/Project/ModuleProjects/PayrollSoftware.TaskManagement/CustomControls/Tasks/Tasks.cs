using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace PayrollSoftware.TaskManagement.CustomControls
{
    public class Tasks : Control
    {
        public static readonly DependencyProperty IconProperty =
            DependencyProperty.Register("Icon", typeof(Geometry), typeof(Tasks), new PropertyMetadata(null));

        public static readonly DependencyProperty IsActiveProperty =
            DependencyProperty.Register("IsActive", typeof(bool), typeof(Tasks), new PropertyMetadata(false));

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<Task>), typeof(Tasks), new PropertyMetadata(null));

        public static readonly DependencyProperty KeyProperty =
            DependencyProperty.Register("Key", typeof(string), typeof(Tasks), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty SelectedTaskProperty =
                    DependencyProperty.Register("SelectedTask", typeof(Task), typeof(Tasks), new PropertyMetadata(null));

        public static readonly DependencyProperty TitleProperty =
                                    DependencyProperty.Register("Title", typeof(string), typeof(Tasks), new PropertyMetadata(string.Empty));

        static Tasks()
        {
        }
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }
        private void ItemsSource_CollectionChanged(object? sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
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
    }
}