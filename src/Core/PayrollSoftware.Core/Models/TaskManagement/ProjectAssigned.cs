using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class ProjectAssigned
    {
        public int ProjectId { get; set; }
        public string UserId { get; set; } = null!;
        public DateTime? CreatedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Role { get; set; }
        public string? Status { get; set; }
    }
}
