using Microsoft.EntityFrameworkCore;
using InnoSoft.Core.Constants;
using InnoSoft.Core.Models.TaskManagement;
using Task = InnoSoft.Core.Models.TaskManagement.Task;

namespace InnoSoft.Core.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.SeedDataForProject();
            modelBuilder.SeedDataForTask();
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

        private static void SeedDataForTask(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Task>().HasData(new List<Task>() {
                new() {
                    TaskId = 1,
                    TaskName = "Phát triển phần mềm XBOOM ATS",
                    TaskCode = "XBOOM_ATS_TASK01",
                    Description = "Phát triển phần mềm kiểm tra các chức năng của sản phẩm",
                    CreatedDate = DateTime.Now,
                    DueDate = new DateTime(2024,08,10),
                    Status = TaskState.TODO,
                    Type = "Issue",
                    Priority = "1",
                    ProjectId = 1,
                },
                new() {
                    TaskId = 2,
                    TaskName = "Phát triển module COMPORT",
                    TaskCode = "XBOOM_ATS_TASK02",
                    Description = "Phát triển phần mềm kiểm tra các chức năng của sản phẩm",
                    CreatedDate = DateTime.Now,
                    DueDate = new DateTime(2024,08,10),
                    Status = TaskState.TODO,
                    Type = "Issue",
                    Priority = "1",
                    ProjectId = 1,
                },
                new() {
                    TaskId = 3,
                    TaskName = "Phát triển module VIDEO",
                    TaskCode = "XBOOM_ATS_TASK03",
                    Description = "Phát triển phần mềm kiểm tra các chức năng của sản phẩm",
                    CreatedDate = DateTime.Now,
                    DueDate = new DateTime(2024,08,10),
                    Status = TaskState.TODO,
                    Type = "Issue",
                    Priority = "1",
                    ProjectId = 1,
                },
                new() {
                    TaskId = 4,
                    TaskName = "Phát triển module DMM",
                    TaskCode = "XBOOM_ATS_TASK04",
                    Description = "Phát triển phần mềm kiểm tra các chức năng của sản phẩm",
                    CreatedDate = DateTime.Now,
                    DueDate = new DateTime(2024,08,10),
                    Status = TaskState.TODO,
                    Type = "Issue",
                    Priority = "1",
                    ProjectId = 1,
                },
                new() {
                    TaskId = 5,
                    TaskName = "Phát triển module AUDIO",
                    TaskCode = "XBOOM_ATS_TASK05",
                    Description = "Phát triển phần mềm kiểm tra các chức năng của sản phẩm",
                    CreatedDate = DateTime.Now,
                    DueDate = new DateTime(2024,08,10),
                    Status = TaskState.TODO,
                    Type = "Issue",
                    Priority = "1",
                    ProjectId = 1,
                },
                new() {
                    TaskId = 6,
                    TaskName = "Phát triển module Data logger",
                    TaskCode = "XBOOM_ATS_TASK06",
                    Description = "Phát triển phần mềm kiểm tra các chức năng của sản phẩm",
                    CreatedDate = DateTime.Now,
                    DueDate = new DateTime(2024,08,10),
                    Status = "Cần làm",
                    Type = "Issue",
                    Priority = "1",
                    ProjectId = 1,
                }
            });
        }
    }
}