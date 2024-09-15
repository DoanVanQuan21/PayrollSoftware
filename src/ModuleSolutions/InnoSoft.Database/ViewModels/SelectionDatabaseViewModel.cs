using InnoSoft.Core.Contracts;
using InnoSoft.Core.Events;
using InnoSoft.Core.Models;
using InnoSoft.Core.Models.Common;
using InnoSoft.Core.Mvvms;
using InnoSoft.Database.Views;
using Prism.Commands;
using Prism.Services.Dialogs;
using System.Windows.Input;

namespace InnoSoft.Database.ViewModels
{
    internal class SelectionDatabaseViewModel : BaseRegionViewModel
    {
        private readonly IAppManager _appManager;
        private ServerInfor currentServerInfor;

        public SelectionDatabaseViewModel()
        {
            _appManager = Ioc.Resolve<IAppManager>();
        }

        public BootSetting? BootSetting { get => _appManager.BootSetting; }

        public ServerInfor CurrentServerInfor
        { get => currentServerInfor; set { SetProperty(ref currentServerInfor, value); } }

        public ICommand AddServerInfor { get; set; }
        public ICommand SelectedDatabaseCommand { get; set; }
        public ICommand DeleteServerInforCommand { get; set; }
        public ICommand UpdateServerInforCommand { get; set; }
        public ICommand ConnectServerInforCommand { get; set; }
        public override string Title => "Selection Database";

        protected override void RegisterCommand()
        {
            AddServerInfor = new DelegateCommand(OnAdd);
            SelectedDatabaseCommand = new DelegateCommand<ServerInfor>(OnSelectedDatabase);
            DeleteServerInforCommand = new DelegateCommand(OnDeleteServerInfor);
            UpdateServerInforCommand = new DelegateCommand(OnUpdateServerInfor);
            ConnectServerInforCommand = new DelegateCommand(OnConnectServerInfor);
        }

        private void OnConnectServerInfor()
        {
            if (CurrentServerInfor == null)
            {
                return;
            }
            _appManager.BootSetting.CurrentServerInfor = currentServerInfor;
            EventAggregator.GetEvent<RequiredConnectionDatabase>().Publish();
            _appManager.BootSetting.IsSelectedDatabase = true;
        }

        private void OnUpdateServerInfor()
        {
            var serverInfor = _appManager.BootSetting.ServerInfors.FirstOrDefault(item => item.ID == currentServerInfor.ID);
            if (serverInfor == null)
            {
                return;
            }
            serverInfor.Name = currentServerInfor.Name;
            serverInfor.ConnectionString = currentServerInfor.ConnectionString;
        }

        private void OnDeleteServerInfor()
        {
            var serverInfor = _appManager.BootSetting.ServerInfors.FirstOrDefault(item => item.ID == currentServerInfor.ID);
            if (serverInfor == null)
            {
                return;
            }
            _appManager.BootSetting.ServerInfors.Remove(serverInfor);
        }

        private void OnSelectedDatabase(ServerInfor infor)
        {
            CurrentServerInfor = new()
            {
                ID = infor.ID,
                Name = infor.Name,
                ConnectionString = infor.ConnectionString,
                State = infor.State,
            };
        }

        private void OnAdd()
        {
            DialogService.ShowDialog(nameof(AddServerInforView));
        }
    }
}