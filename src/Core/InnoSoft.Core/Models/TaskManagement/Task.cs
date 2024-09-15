using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace InnoSoft.Core.Models.TaskManagement
{
    public partial class Task : BindableBase
    {
        private long taskId;
        private string? taskCode;
        private string? taskName;
        private string? description;
        private DateTime? createdDate;
        private DateTime? updatedDate;
        private DateTime? dueDate;
        private string? status;
        private string? type;
        private string? priority;
        private DateTime? completionDate;
        private DateTime? startDate;
        private int projectId;
        private int userId;

        public Task()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            Comments = new HashSet<Comment>();
        }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long TaskId { get => taskId; set => SetProperty(ref taskId,value); }
        public string? TaskCode { get => taskCode; set => SetProperty(ref taskCode,value); }
        public string? TaskName { get => taskName; set => SetProperty(ref taskName, value); }
        public string? Description { get => description; set => SetProperty(ref description, value); }
        public DateTime? CreatedDate { get => createdDate; set => SetProperty(ref createdDate, value); }
        public DateTime? UpdatedDate { get => updatedDate; set => SetProperty(ref updatedDate, value); }
        public DateTime? DueDate { get => dueDate; set => SetProperty(ref dueDate, value); }
        public string? Status { get => status; set => SetProperty(ref status, value); }
        public string? Type { get => type; set => SetProperty(ref type, value); }
        public string? Priority { get => priority; set => SetProperty(ref priority, value); }
        public DateTime? CompletionDate { get => completionDate; set => SetProperty(ref completionDate, value); }
        public DateTime? StartDate { get => startDate; set => SetProperty(ref startDate, value); }
        public int ProjectId { get => projectId; set => SetProperty(ref projectId, value); }
        public int UserId { get => userId; set => SetProperty(ref userId, value); }

        public virtual Project Project { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
