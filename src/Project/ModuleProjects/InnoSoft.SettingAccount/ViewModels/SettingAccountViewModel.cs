using InnoSoft.Core.Models.TaskManagement;
using InnoSoft.Core.Mvvms;
using InnoSoft.Core.Services;
using InnoSoft.EntityFramework.Contracts;
using Prism.Commands;
using System.Windows.Input;

namespace InnoSoft.SettingAccount.ViewModels
{
    internal class SettingAccountViewModel : BaseRegionViewModel
    {
        private readonly ITaskManagementService _taskManagementService;
        public override string Title => "SettingAcount";
        private User? user;

        public User? User
        {
            get { return user; }
            set { SetProperty(ref user, value); }
        }

        public SettingAccountViewModel()
        {
            _taskManagementService = Ioc.Resolve<ITaskManagementService>();
            if (_taskManagementService == null)
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
            if (_taskManagementService == null)
            {
                await CustomNotification.Warning("Lỗi database. Vui lòng kiểm tra kết nối!");
                return;
            }
            var isUpdate = await _taskManagementService.UserRepository.Update(User);
            if (isUpdate)
            {
                await CustomNotification.Success("Cập nhật thông tin thành công!");
                BootSetting.CurrentUser = User;
                return;
            }
            await CustomNotification.Error($"{BootSetting.CurrentUser.FullName} không tồn tại trong database!");
        }

        private async void OnResetInforUser()
        {
            if (BootSetting.CurrentUser == null)
            {
                await CustomNotification.Warning("Không lấy được thông tin cũ!");
                return;
            }
            //TODO
            User = new User(BootSetting.CurrentUser);
            await CustomNotification.Success("Khôi phục thông tin thành công!");
        }
    }
}