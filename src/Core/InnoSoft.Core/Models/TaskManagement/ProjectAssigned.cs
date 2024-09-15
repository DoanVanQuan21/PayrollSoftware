using Prism.Mvvm;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnoSoft.Core.Models.TaskManagement
{
    public partial class ProjectAssigned : BindableBase
    {
        private int projectId;
        private string userId = null!;
        private DateTime? createdDate;
        private DateTime? endDate;
        private string? role;
        private string? status;

        public int ProjectId { get => projectId; set => SetProperty(ref projectId, value); }
        public string UserId { get => userId; set => SetProperty(ref userId, value); }
        public DateTime? CreatedDate { get => createdDate; set => SetProperty(ref createdDate, value); }
        public DateTime? EndDate { get => endDate; set => SetProperty(ref endDate, value); }
        public string? Role { get => role; set => SetProperty(ref role, value); }
        public string? Status { get => status; set => SetProperty(ref status, value); }

        [NotMapped]
        public User Employee { get; set; } = null!;

        [NotMapped]
        public Project Project { get; set; } = null!;
    }
}