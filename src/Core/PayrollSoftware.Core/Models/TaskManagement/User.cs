using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSoftware.Core.Models.TaskManagement
{
    public partial class User : BindableBase
    {
        private string? address;
        private DateTime? createdDate;
        private DateTime? dateOfBirth;
        private string? email;
        private DateTime? endDate;
        private string? firstName;
        private string fullName;
        private string? identificationCard;
        private string? image;
        private string? jobPosition;
        private string? lastName;
        private bool? lockAccount;
        private string password;
        private string? phone;
        private string? role;
        private string? status;
        private string? userCode;
        private int userId;
        private string username;
        public User()
        {
            ActivityLogs = new HashSet<ActivityLog>();
            Comments = new HashSet<Comment>();
            Tasks = new HashSet<Task>();
            UpdateFullName();
        }

        public User(User user)
        {
            if (user == null)
            {
                return;
            }
            UserId = user.UserId;
            UserCode = user.UserCode;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DateOfBirth = user.DateOfBirth;
            Address = user.Address;
            Phone = user.Phone;
            Email = user.Email;
            Role = user.Role;
            IdentificationCard = user.IdentificationCard;
            JobPosition = user.JobPosition;
            CreatedDate = user.CreatedDate;
            EndDate = user.EndDate;
            Username = user.Username;
            Password = user.Password;
            LockAccount = user.LockAccount;
            Status = user.Status;
        }

        [Browsable(false)]
        public virtual ICollection<ActivityLog> ActivityLogs { get; set; }

        public string? Address { get => address; set => SetProperty(ref address, value); }

        [Browsable(false)]
        public virtual ICollection<Comment> Comments { get; set; }

        public DateTime? CreatedDate { get => createdDate; set => SetProperty(ref createdDate, value); }

        public DateTime? DateOfBirth { get => dateOfBirth; set => SetProperty(ref dateOfBirth, value); }

        public string? Email { get => email; set => SetProperty(ref email, value); }

        [Browsable(false)]
        public DateTime? EndDate { get => endDate; set => SetProperty(ref endDate, value); }

        public string? FirstName
        { get => firstName; set { SetProperty(ref firstName, value); UpdateFullName(); } }

        [NotMapped]
        public string FullName { get => fullName; set => SetProperty(ref fullName, value); }

        public string? IdentificationCard { get => identificationCard; set => SetProperty(ref identificationCard, value); }

        public string? Image { get => image; set => SetProperty(ref image, value); }

        public string? JobPosition { get => jobPosition; set => SetProperty(ref jobPosition, value); }

        public string? LastName
        { get => lastName; set { SetProperty(ref lastName, value); UpdateFullName(); } }

        [Browsable(false)]
        public bool? LockAccount { get => lockAccount; set => SetProperty(ref lockAccount, value); }

        [Browsable(false)]
        public string Password { get => password; set => SetProperty(ref password, value); }

        public string? Phone { get => phone; set => SetProperty(ref phone, value); }

        public string? Role { get => role; set => SetProperty(ref role, value); }

        [Browsable(false)]
        public string? Status { get => status; set => SetProperty(ref status, value); }

        [Browsable(false)]
        public virtual ICollection<Task> Tasks { get; set; }

        public string? UserCode { get => userCode; set => SetProperty(ref userCode, value); }

        [Browsable(false)]
        public int UserId { get => userId; set => SetProperty(ref userId, value); }
        [Browsable(false)]
        public string Username { get => username; set => SetProperty(ref username, value); }
        private void UpdateFullName()
        {
            FullName = $"{FirstName} {LastName}";
        }
    }
}