using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.TaskManagement.ViewModels;
using System.Windows.Controls;

namespace PayrollSoftware.TaskManagement.Views
{
    public partial class TasksView : UserControl
    {
        public TasksView()
        {
            InitializeComponent();
            DataContext = Ioc.Resolve<TasksViewModel>();
        }
    }
}