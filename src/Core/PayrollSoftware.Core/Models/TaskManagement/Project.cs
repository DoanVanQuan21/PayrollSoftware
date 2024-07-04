using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class Project
    {
        public Project()
        {
            Comments = new HashSet<Comment>();
            Tasks = new HashSet<Task>();
        }

        public int ProjectId { get; set; }
        public string? ProjectCode { get; set; }
        public string? ProjectName { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? Descriptions { get; set; }
        public string? Status { get; set; }
        public bool Disable { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}
