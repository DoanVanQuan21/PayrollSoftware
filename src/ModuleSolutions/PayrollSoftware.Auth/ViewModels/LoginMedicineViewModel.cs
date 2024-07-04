using PayrollSoftware.Auth.Contracts;
using PayrollSoftware.Core.Events;
using PayrollSoftware.Core.Models.TaskManagement;
using PayrollSoftware.Core.Mvvms;
using Prism.Commands;
using System.Windows.Controls;

namespace PayrollSoftware.Auth.ViewModels
{
    public class LoginMedicineViewModel : BaseRegionViewModel
    {
        private readonly ILoginService _loginService;
        public User User { get; set; }
        public override string Title => "Đăng nhập";

        public LoginMedicineViewModel() : base()
        {
            _loginService = Ioc.Resolve<ILoginService>();
            User = new();
        }

        protected override void RegisterCommand()
        {
            LoginCommand = new DelegateCommand(OnLogin);
        }

        private async void OnLogin()
        {
            if (User == null)
            {
                EventAggregator.GetEvent<LoginSuccessEvent>().Publish(false);
                return;
            }
            EventAggregator.GetEvent<LoginSuccessEvent>().Publish(await _loginService.LoginAsync(User));
        }

    }
}