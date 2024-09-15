using Prism.Commands;
using System.Windows.Input;

namespace InnoSoft.Core.Mvvms
{
    public abstract class ManagementRegionViewModel : BaseRegionViewModel
    {
        public List<int> Rows = new() { 5, 10, 15, 20, 25, 30 };
        private int pageIndex=0;
        private int row=10;

        protected ManagementRegionViewModel() : base()
        {
        }

        public int PageIndex
        { get => pageIndex; set { SetProperty(ref pageIndex, value); UpdateRow().GetAwaiter(); } }

        public ICommand PageUpdatedCmd { get; set; }

        public int Row
        { get => row; set { SetProperty(ref row, value); UpdateRow().GetAwaiter(); } }

        public virtual Task UpdateRow()
        {
            return Task.CompletedTask;
        }

        protected virtual void OnPageUpdate()
        {
        }

        protected override void RegisterCommand()
        {
            PageUpdatedCmd = new DelegateCommand(OnPageUpdate);
        }
    }
}