using Prism.Mvvm;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class Project : BindableBase
    {
        private int projectId;
        private string? projectCode;
        private string? projectName;
        private DateTime? createdDate;
        private DateTime? endDate;
        private DateTime? updateDate;
        private string? descriptions;
        private string? status;
        private bool disable;

        public Project()
        {
            Comments = new HashSet<Comment>();
            Tasks = new HashSet<Task>();
        }

        public int ProjectId { get => projectId; set => SetProperty(ref projectId, value); }
        public string? ProjectCode { get => projectCode; set => SetProperty(ref projectCode, value); }
        public string? ProjectName { get => projectName; set => SetProperty(ref projectName, value); }
        public DateTime? CreatedDate { get => createdDate; set => SetProperty(ref createdDate, value); }
        public DateTime? EndDate { get => endDate; set => SetProperty(ref endDate, value); }
        public DateTime? UpdateDate { get => updateDate; set => SetProperty(ref updateDate, value); }
        public string? Descriptions { get => descriptions; set => SetProperty(ref descriptions, value); }
        public string? Status { get => status; set => SetProperty(ref status, value); }
        public bool Disable { get => disable; set => SetProperty(ref disable, value); }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}