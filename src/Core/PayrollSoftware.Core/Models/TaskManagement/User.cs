using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class User
    {
        public User()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            Comments = new HashSet<Comment>();
            Tasks = new HashSet<Task>();
        }

        public int UserId { get; set; }
        public string? UserCode { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string? IdentificationCard { get; set; }
        public string? JobPosition { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool? LockAccount { get; set; }
        public string Status { get; set; }
        [NotMapped]
        public string FullName => $"{FirstName} {LastName}";

        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}