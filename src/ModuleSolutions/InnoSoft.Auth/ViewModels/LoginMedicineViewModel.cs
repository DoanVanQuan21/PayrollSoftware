using InnoSoft.Core.Dialogs;
using InnoSoft.Core.Events;
using InnoSoft.Core.Models.TaskManagement;
using InnoSoft.Core.Mvvms;
using Prism.Commands;
using System.Windows.Input;
using Task = System.Threading.Tasks.Task;
using InnoSoft.Auth.Contracts;

namespace InnoSoft.Auth.ViewModels
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