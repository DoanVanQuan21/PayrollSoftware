using InnoSoft.Core.Mvvms;
using InnoSoft.TaskManagement.ViewModels;
using System.Windows.Controls;
using System.Windows.Input;

namespace InnoSoft.TaskManagement.Views
{
    /// <summary>
    /// Interaction logic for TasksView.xaml
    /// </summary>
    public partial class TasksView : UserControl
    {
        public TasksView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<TasksViewModel>();
        }

        private void ListBox_MouseLeave(object sender, MouseEventArgs e)
        {
            
        }
    }
}