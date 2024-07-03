using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.SchoolManager
{
    public partial class Assignment
    {
        public string? Position { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Status { get; set; }
        public long UserId { get; set; }
        public long ClassroomId { get; set; }
        public long CourseId { get; set; }
    }
}
