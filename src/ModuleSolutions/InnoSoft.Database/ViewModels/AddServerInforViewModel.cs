using InnoSoft.Core.Contracts;
using InnoSoft.Core.Models.Common;
using InnoSoft.Core.Mvvms;
using Prism.Commands;
using Prism.Services.Dialogs;
using System.Windows.Input;

namespace InnoSoft.Database.ViewModels
{
    internal class AddServerInforViewModel : BaseRegionViewModel
    {
        private readonly IAppManager _appManager;
        public ServerInfor ServerInfor { get; set; }
        public override string Title => "Add server info";

        public AddServerInforViewModel()
        {
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public ICommand AddCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        protected override void RegisterCommand()
        {
            AddCommand = new DelegateCommand(OnAdd);
            CancelCommand = new DelegateCommand(OnCancel);
        }

        private void OnCancel()
        {
            CloseDialog("false");
        }

        private void OnAdd()
        {
            _appManager.BootSetting.ServerInfors.Add(ServerInfor);
        }

        public override void OnDialogOpened(IDialogParameters parameters)
        {
            ServerInfor = new();
            base.OnDialogOpened(parameters);
        }
    }
}