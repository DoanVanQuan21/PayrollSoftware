using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.SchoolManager
{
    public partial class Course
    {
        public long CourseId { get; set; }
        public string? CourseCode { get; set; }
        public string? CourseContent { get; set; }
        public int? NumberLesson { get; set; }
        public long SubjectId { get; set; }
        public long DepartmentId { get; set; }
    }
}
