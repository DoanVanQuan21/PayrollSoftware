using PayrollSoftware.Core.Editors;
using Prism.Mvvm;
using System.ComponentModel;

namespace PayrollSoftware.Core.Models.SchoolManager
{
    public partial class User : BindableBase
    {
        private long userId;
        private long departmentId;
        private string? userCode;
        private string? surname;
        private string? name;
        private bool gender;
        private DateTime? birthday;
        private string? phoneNumber;
        private string? address;
        private string? email;
        private string? username;
        private string? password;
        private string? cartificate;
        private string? specializedIn;
        private string? role;
        private string? state;
        private DateTime? dateStartWork;
        private DateTime? dateOff;
        private string? image;

        [Browsable(false)]
        public long UserId
        { get => userId; set { SetProperty(ref userId, value); } }

        [Browsable(false)]
        public long DepartmentId
        { get => departmentId; set { SetProperty(ref departmentId, value); } }

        [DisplayName("Mã nhân viên")]
        public string? UserCode
        { get => userCode; set { SetProperty(ref userCode, value); } }

        [DisplayName("Họ đệm")]
        public string? Surname
        { get => surname; set { SetProperty(ref surname, value); } }

        [DisplayName("Tên")]
        public string? Name
        { get => name; set { SetProperty(ref name, value); } }

        [Browsable(false)]
        public string? Fullname { get => $"{Surname} {Name}"; }

        [DisplayName("Giới tính")]
        [Editor(typeof(GenderPropertyEditor), typeof(GenderPropertyEditor))]
        public bool Gender
        { get => gender; set { SetProperty(ref gender, value); } }

        [Browsable(false)]
        public string AcctualGender { get => gender ? "Nam" : "Nữ"; }

        [DisplayName("Ngày sinh")]
        public DateTime? Birthday
        { get => birthday; set { SetProperty(ref birthday, value); } }

        [DisplayName("Số điện thoại")]
        public string? PhoneNumber
        { get => phoneNumber; set { SetProperty(ref phoneNumber, value); } }

        [DisplayName("Địa chỉ")]
        public string? Address
        { get => address; set { SetProperty(ref address, value); } }

        [DisplayName("Email")]
        public string? Email
        { get => email; set { SetProperty(ref email, value); } }

        [Browsable(false)]
        public string? Image
        { get => image; set { SetProperty(ref image, value); } }

        [Browsable(false)]
        public string? Username
        { get => username; set { SetProperty(ref username, value); } }

        [Browsable(false)]
        public string? Password
        { get => password; set { SetProperty(ref password, value); } }

        [DisplayName("Chứng chỉ")]
        public string? Cartificate
        { get => cartificate; set { SetProperty(ref cartificate, value); } }

        [DisplayName("Chuyên môn")]
        public string? SpecializedIn
        { get => specializedIn; set { SetProperty(ref specializedIn, value); } }

        [Browsable(false)]
        public string? Role
        { get => role; set { SetProperty(ref role, value); } }

        [Browsable(false)]
        public string? State
        { get => state; set { SetProperty(ref state, value); } }

        [Browsable(false)]
        public DateTime? DateStartWork
        { get => dateStartWork; set { SetProperty(ref dateStartWork, value); } }

        [Browsable(false)]
        public DateTime? DateOff
        { get => dateOff; set { SetProperty(ref dateOff, value); } }

        public User()
        {
        }

        public User(User user)
        {
            UserId = user.UserId;
            DepartmentId = user.DepartmentId;
            UserCode = user.UserCode;
            Surname = user.Surname;
            Name = user.Name;
            Gender = user.Gender;
            Birthday = user.Birthday;
            PhoneNumber = user.PhoneNumber;
            Address = user.Address;
            Email = user.Email;
            Username = user.Username;
            Password = user.Password;
            Cartificate = user.Cartificate;
            SpecializedIn = user.SpecializedIn;
            Role = user.Role;
            State = user.State;
            DateStartWork = user.DateStartWork;
            DateOff = user.DateOff;
            Image = user.Image;
        }
    }
}