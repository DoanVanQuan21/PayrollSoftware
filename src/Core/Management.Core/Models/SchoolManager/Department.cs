using System;
using System.Collections.Generic;

namespace Management.Core.Models.SchoolManager
{
    public partial class Department
    {
        public long DepartmentId { get; set; }
        public string? DepartmentCode { get; set; }
        public string? DepartmentName { get; set; }
        public long? HeadOfDepartment { get; set; }
    }
}
