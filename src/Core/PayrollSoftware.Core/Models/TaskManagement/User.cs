using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class User : BindableBase
    {
        private int userId;
        private string? userCode;
        private string? firstName;
        private string? lastName;
        private DateTime? dateOfBirth;
        private string? address;
        private string? phone;
        private string? email;
        private string? role;
        private string? identificationCard;
        private string? jobPosition;
        private DateTime createdDate;
        private DateTime endDate;
        private string username;
        private string password;
        private bool? lockAccount;
        private string status;
        private string fullName;

        public User()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            Comments = new HashSet<Comment>();
            Tasks = new HashSet<Task>();
        }

        public int UserId { get => userId; set => SetProperty(ref userId, value); }
        public string? UserCode { get => userCode; set => SetProperty(ref userCode, value); }

        public string? FirstName
        { get => firstName; set { SetProperty(ref firstName, value); UpdateFullName(); } }

        public string? LastName
        { get => lastName; set { SetProperty(ref lastName, value); UpdateFullName(); } }

        public DateTime? DateOfBirth { get => dateOfBirth; set => SetProperty(ref dateOfBirth, value); }
        public string? Address { get => address; set => SetProperty(ref address, value); }
        public string? Phone { get => phone; set => SetProperty(ref phone, value); }
        public string? Email { get => email; set => SetProperty(ref email, value); }
        public string? Role { get => role; set => SetProperty(ref role, value); }
        public string? IdentificationCard { get => identificationCard; set => SetProperty(ref identificationCard, value); }
        public string? JobPosition { get => jobPosition; set => SetProperty(ref jobPosition, value); }
        public DateTime CreatedDate { get => createdDate; set => SetProperty(ref createdDate, value); }
        public DateTime EndDate { get => endDate; set => SetProperty(ref endDate, value); }
        public string Username { get => username; set => SetProperty(ref username, value); }
        public string Password { get => password; set => SetProperty(ref password, value); }
        public bool? LockAccount { get => lockAccount; set => SetProperty(ref lockAccount, value); }
        public string Status { get => status; set => SetProperty(ref status, value); }

        [NotMapped]
        public string FullName { get => fullName; set => SetProperty(ref fullName, value); }

        private void UpdateFullName()
        {
            FullName = $"{FirstName} {LastName}";
        }

        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Task> Tasks { get; set; }
    }
}