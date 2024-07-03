using System;
using System.Collections.Generic;

namespace Management.Core.Models.SchoolManager
{
    public partial class Subject
    {
        public long SubjectId { get; set; }
        public string? SubjectCode { get; set; }
        public string? SubjectName { get; set; }
    }
}
