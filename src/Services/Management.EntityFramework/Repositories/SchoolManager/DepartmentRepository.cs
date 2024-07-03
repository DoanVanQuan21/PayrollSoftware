﻿using Management.Core.Models.SchoolManager;

namespace Management.EntityFramework.Repositories.SchoolManager
{
    public class DepartmentRepository : GenericRepository<Department>
    {
        public DepartmentRepository(SchoolManagerContext context) : base(context)
        {
        }

        public override Department? GetByCode(string code)
        {
            return _context.Departments.FirstOrDefault(item => item.DepartmentCode == code);
        }

        public override Department? GetById(int id)
        {
            return _context.Departments.FirstOrDefault(item => item.DepartmentId == id);
        }
    }
}