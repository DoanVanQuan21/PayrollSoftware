using Management.Auth.Contracts;
using Management.Core.Events;
using Management.Core.Models.SchoolManager;
using Management.Core.Mvvms;
using Prism.Commands;
using System.Windows.Controls;

namespace Management.Auth.ViewModels
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

        private void OnLogin()
        {
            if (User == null)
            {
                EventAggregator.GetEvent<LoginSuccessEvent>().Publish(false);
                return;
            }
            EventAggregator.GetEvent<LoginSuccessEvent>().Publish(_loginService.Login(User));
        }

    }
}