using Management.Auth.Views.UserControls;
using Management.Core.Contracts;
using Management.Core.Events;
using Management.Core.Mvvms;
using Management.Database.Views;

namespace Management.Shell.ViewModels
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