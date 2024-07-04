using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class Task
    {
        public Task()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            Comments = new HashSet<Comment>();
        }

        public long TaskId { get; set; }
        public string? TaskCode { get; set; }
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DueDate { get; set; }
        public string? Status { get; set; }
        public string? Type { get; set; }
        public string? Priority { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? StartDate { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual User User { get; set; } = null!;
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
