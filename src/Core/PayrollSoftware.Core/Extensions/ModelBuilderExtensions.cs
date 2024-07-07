using Microsoft.EntityFrameworkCore;
using PayrollSoftware.Core.Models.TaskManagement;

namespace PayrollSoftware.Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDataForProject();
        }
        private static void SeedDataForProject(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasData(new List<Project>()
            {
                new()
                {
                    ProjectId = 1,
                    ProjectCode = "PJ001",
                    ProjectName = "XBOOM ATS",
                    CreatedDate = DateTime.Now,
                    Status = "Active",
                    Disable =false
                },
                 new()
                {
                    ProjectId = 2,
                    ProjectCode = "PJ002",
                    ProjectName = "MOONPO ATS",
                    CreatedDate = DateTime.Now,
                    Status = "Active",
                    Disable =false
                }, new()
                {
                    ProjectId = 3,
                    ProjectCode = "PJ003",
                    ProjectName = "MARUSYS ATS",
                    CreatedDate = DateTime.Now,
                    Status = "Active",
                    Disable =false
                }, new()
                {
                    ProjectId = 4,
                    ProjectCode = "PJ004",
                    ProjectName = "X3/X4 ATS",
                    CreatedDate = DateTime.Now,
                    Status = "Active",
                    Disable =false
                }
            });
        }
    }
}