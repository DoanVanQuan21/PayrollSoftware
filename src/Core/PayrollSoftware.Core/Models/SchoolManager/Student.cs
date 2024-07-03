using System;
using System.Collections.Generic;

namespace PayrollSoftware.Core.Models.SchoolManager
{
    public partial class Student
    {
        public long StudentId { get; set; }
        public string? StudentCode { get; set; }
        public string? StudentFullname { get; set; }
        public bool? StudentGender { get; set; }
        public DateTime? StudentBirthday { get; set; }
        public string? StudentPhone { get; set; }
        public string? StudentAddress { get; set; }
        public long ClassroomId { get; set; }
    }
}
