using PayrollSoftware.Auth.Contracts;
using PayrollSoftware.Core.Dialogs;
using PayrollSoftware.Core.Events;
using PayrollSoftware.Core.Models.TaskManagement;
using PayrollSoftware.Core.Mvvms;
using Prism.Commands;
using System.Windows.Input;
using Task = System.Threading.Tasks.Task;

namespace PayrollSoftware.Auth.ViewModels
{
    public class LoginMedicineViewModel : BaseRegionViewModel
    {
        private readonly ILoginService _loginService;
        public User User { get; set; }
        public override string Title => "Đăng nhập";
        public ICommand ExitCommand { get; set; }
        public LoginMedicineViewModel() : base()
        {
            _loginService = Ioc.Resolve<ILoginService>();
            User = new();
        }

        protected override void RegisterCommand()
        {
            LoginCommand = new DelegateCommand(OnLogin);
            ExitCommand = new DelegateCommand(OnExit);
        }

        private void OnExit()
        {
            EventAggregator.GetEvent<ExitApplicationEvent>().Publish();
        }

        private async void OnLogin()
        {
            ShowLoadingDialog();
            if (User == null)
            {
                EventAggregator.GetEvent<LoginSuccessEvent>().Publish(false);
                return;
            }
            await Task.Delay(1000);
            EventAggregator.GetEvent<LoginSuccessEvent>().Publish(await _loginService.LoginAsync(User));
        }
    }
}