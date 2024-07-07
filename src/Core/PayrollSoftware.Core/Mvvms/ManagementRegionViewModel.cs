using Prism.Commands;
using System.Windows.Input;

namespace PayrollSoftware.Core.Mvvms
{
    public abstract class ManagementRegionViewModel : BaseRegionViewModel
    {
        public List<int> Rows = new() { 5, 10, 15, 20, 25, 30 };
        private int pageIndex;
        private int row=10;
        private int maxPage = 5;

        protected ManagementRegionViewModel() : base()
        {
        }

        public int MaxPage { get => maxPage; set => SetProperty(ref maxPage, value); }

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