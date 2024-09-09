using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Events;
using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Models.Common;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Windows.Controls;
using System.Windows.Input;

namespace PayrollSoftware.Core.Mvvms
{
    public abstract class BaseRegionViewModel : BindableBase, IDialogAware
    {
        protected readonly IEventAggregator EventAggregator;
        private readonly IAppManager _appManager;
        private readonly ICustomDialog _dialog;
        private bool isLogin = false;

        public BaseRegionViewModel()
        {
            _appManager = Ioc.Resolve<IAppManager>();
            EventAggregator = Ioc.Resolve<IEventAggregator>();
            DialogService = Ioc.Resolve<IDialogService>();
            _dialog = Ioc.Resolve<ICustomDialog>();
            EventAggregator.GetEvent<LoginSuccessEvent>().Subscribe(OnLogginSuccess);
            RegisterCommand();
            RegisterEvent();
        }

        public event Action<IDialogResult>? RequestClose;

        public ICommand AddCommand { get; set; }
        public AppRegion AppRegion { get => _appManager.AppRegion; }
        public BootSetting BootSetting { get => _appManager.BootSetting; }
        public ICommand CancelCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

        public bool IsLogin
        { get => isLogin; set { SetProperty(ref isLogin, value); } }

        public ICommand? KeyUpCommand { get; set; }
        public ICommand LoadedCommand { get; set; }
        public ICommand? LoginCommand { get; set; }
        public abstract string Title { get; }
        public ICommand UnLoadedCommand { get; set; }
        protected IDialogService DialogService { get; private set; }

        public virtual bool CanCloseDialog()
        {
            return true;
        }

        public virtual void OnDialogClosed()
        {
        }

        public virtual void OnDialogOpened(IDialogParameters parameters)
        {
        }

        public virtual void RaiseRequestClose(IDialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }

        protected virtual void CloseDialog(string parameter = "")
        {
            ButtonResult res = ButtonResult.None;
            if (parameter?.ToLower() == "true")
            {
                res = ButtonResult.OK;
                RaiseRequestClose(new DialogResult(res));
                return;
            }
            res = ButtonResult.Cancel;
            RaiseRequestClose(new DialogResult(res));
        }

        protected virtual void CloseDialog()
        {
            _dialog.Close();
        }

        protected void DefaultView()
        {
            AppRegion.RegionPage = null;
        }

        protected virtual void OnLoaded()
        {
        }

        protected virtual void RegisterCommand()
        {
            LoadedCommand = new DelegateCommand(OnLoaded);
            UnLoadedCommand = new DelegateCommand(UnLoaded);
        }

        protected void ShowProgressBar()
        {
            var progressBar = new Dialogs.ProgressBar();
            ShowDialog(progressBar);
        }

        protected virtual void RegisterEvent()
        { }

        protected virtual void SetMainPage(UserControl control)
        {
            AppRegion.RegionPage = control;
        }

        protected virtual void SetMainView(UserControl control)
        {
            AppRegion.MainRegion = control;
        }

        protected virtual void ShowDialog(UserControl control)
        {
            _dialog.Show(control);
        }

        protected virtual void UnLoaded()
        {
        }

        private void OnLogginSuccess(bool isLoginSucess)
        {
            if (!isLoginSucess)
            {
                return;
            }
            SetStateLogin(true);
        }

        private void SetStateLogin(bool isLogin)
        {
            IsLogin = isLogin;
        }
    }
}