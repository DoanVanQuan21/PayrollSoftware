using Management.Core.Models.SchoolManager;
using Management.Core.Mvvms;
using Management.SchoolManagement.Accounts.Contracts;
using System.Collections.ObjectModel;

namespace Management.SchoolManagement.Accounts.ViewModels
{
    public class AccountsViewModel : BaseRegionViewModel
    {
        private readonly IAccountManager _accountManager;
        public override string Title => "Danh sách tài khoản";
        public ObservableCollection<User> Accounts { get; private set; }

        public AccountsViewModel()
        {
            _accountManager = Ioc.Resolve<IAccountManager>();
            Init();
        }

        protected override void RegisterCommand()
        {
        }

        protected override void RegisterEvent()
        {
        }

        private void Init()
        {
            if (BootSetting.CurrentUser == null)
            {
                return;
            }
            Accounts = _accountManager.GetAccountsByDepartment(BootSetting.CurrentUser.DepartmentId);
        }
    }
}