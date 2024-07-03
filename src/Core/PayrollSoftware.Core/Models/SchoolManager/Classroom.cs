using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.SchoolManager
{
    public partial class Classroom
    {
        public long ClassroomId { get; set; }
        public string? ClassroomCode { get; set; }
        public string? ClassroomName { get; set; }
    }
}
