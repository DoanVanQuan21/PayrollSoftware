using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class Comment
    {
        public long CommentId { get; set; }
        public long? CommentCode { get; set; }
        public string? CommentContent { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int UserId { get; set; }
        public long TaskId { get; set; }
        public int ProjectId { get; set; }

        public virtual Project Project { get; set; } = null!;
        public virtual Task Task { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
