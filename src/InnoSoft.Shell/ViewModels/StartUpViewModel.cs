using InnoSoft.Auth.Views.UserControls;
using InnoSoft.Core.Contracts;
using InnoSoft.Core.Events;
using InnoSoft.Core.Mvvms;
using InnoSoft.Database.Views;

namespace InnoSoft.Shell.ViewModels
{
    internal class StartUpViewModel : BaseRegionViewModel
    {
        private readonly IAppManager _appManager;
        public override string Title => "Đăng nhập";

        public StartUpViewModel()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            InitView();
            EventAggregator.GetEvent<ConnectionDatabaseSuccess>().Subscribe(OnConnectDatabaseSuccess);
        }

        private void InitView()
        {
            if (!_appManager.BootSetting.IsSelectedDatabase)
            {
                SetMainPage(new SelectionDatabaseView());
                return;
            }
            SetMainPage(new LoginMedicineView());
        }

        private void OnConnectDatabaseSuccess()
        {
            SetMainPage(new LoginMedicineView());
        }

    }
}