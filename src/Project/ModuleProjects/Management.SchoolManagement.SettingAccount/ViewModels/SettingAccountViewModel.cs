using PayrollSoftware.Core.Models.SchoolManager;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.Services;
using PayrollSoftware.EntityFramework.Contracts;
using Prism.Commands;
using System.Windows.Input;

namespace Management.SchoolManagement.SettingAccount.ViewModels
{
    internal class SettingAccountViewModel : BaseRegionViewModel
    {
        private readonly ISchoolManagerServer _schoolManagerServer;
        public override string Title => "SettingAcount";
        private User? user;

        public User? User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        public SettingAccountViewModel()
        {
            _schoolManagerServer = Ioc.Resolve<ISchoolManagerServer>();
            if( _schoolManagerServer == null )
            {
                return;
            }
            User = new(BootSetting.CurrentUser);
        }

        public ICommand ResetInforUserCommand { get; set; }
        public ICommand ChangeInforUserCommand { get; set; }

        protected override void RegisterCommand()
        {
            ResetInforUserCommand = new DelegateCommand(OnResetInforUser);
            ChangeInforUserCommand = new DelegateCommand(OnChangeInforUser);
        }

        private async void OnChangeInforUser()
        {
            if (User == null)
            {
                await CustomNotification.Warning("Thông tin không hợp lệ! Vui lòng kiểm tra lại.");
                return;
            }
            if (_schoolManagerServer == null)
            {
                await CustomNotification.Warning("Lỗi database. Vui lòng kiểm tra kết nối!");
                return;
            }
            var isUpdate = _schoolManagerServer.UserRepository.Update(User);
            if (isUpdate)
            {
                await CustomNotification.Success("Cập nhật thông tin thành công!");
                BootSetting.CurrentUser = User;
                return;
            }
            await CustomNotification.Error($"{BootSetting.CurrentUser.Fullname} không tồn tại trong database!");
        }

        private async void OnResetInforUser()
        {
            if (BootSetting.CurrentUser == null)
            {
                await CustomNotification.Warning("Không lấy được thông tin cũ!");
                return;
            }
            User = new User(BootSetting.CurrentUser);
            await CustomNotification.Success("Khôi phục thông tin thành công!");
        }

    }
}