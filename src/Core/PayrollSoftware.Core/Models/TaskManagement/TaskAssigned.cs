using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class TaskAssigned
    {
        public int UserId { get; set; }
        public long TaskId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public DateTime? Status { get; set; }
        public string? Rate { get; set; }
        public string? Comment { get; set; }
        public long? TaskParent { get; set; }
    }
}
