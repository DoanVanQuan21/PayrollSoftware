using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class ActivityLog
    {
        public long ActivityLogId { get; set; }
        public string? Action { get; set; }
        public string? FromStatus { get; set; }
        public string? ToStatus { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public long TaskId { get; set; }
        public int UserId { get; set; }

        public virtual Task Task { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
