using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public class TaskManagementContextFactory : IDesignTimeDbContextFactory<TaskManagementContext>
    {
        TaskManagementContext IDesignTimeDbContextFactory<TaskManagementContext>.CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TaskManagementContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-L2UOCU2;Initial Catalog=TaskManagement;Integrated Security=True;Trust Server Certificate=True");

            return new TaskManagementContext(optionsBuilder.Options);
        }
    }
}