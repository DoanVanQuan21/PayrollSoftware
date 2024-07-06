namespace PayrollSoftware.Core.Mvvms
{
    public abstract class ManagementRegionViewModel : BaseRegionViewModel
    {
        private int pageIndex;
        private int row;

        public int PageIndex
        { get => pageIndex; set { SetProperty(ref pageIndex, value); UpdateRow().GetAwaiter(); } }

        public int Row
        { get => row; set { SetProperty(ref row, value); UpdateRow().GetAwaiter(); } }

        public List<int> Rows = new() { 5, 10, 15, 20, 25, 30 };

        public virtual Task UpdateRow()
        {
            return Task.CompletedTask;
        }
    }
}