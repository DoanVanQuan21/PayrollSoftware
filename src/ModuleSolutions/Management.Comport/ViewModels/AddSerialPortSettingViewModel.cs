using Management.Core.Mvvms;
using Management.Core.Settings.Comports;
using Prism.Commands;
using System.Windows.Input;

namespace Management.Comport.ViewModels
{
    public class AddSerialPortSettingViewModel : BaseRegionViewModel
    {
        public Action<SerialPortSetting> AddAction;
        public AddSerialPortSettingViewModel()
        {
            SerialPortSetting = new SerialPortSetting();
        }

        public SerialPortSetting SerialPortSetting { get; set; }
        public override string Title => "Add Device";
        protected override void RegisterCommand()
        {
            AddCommand = new DelegateCommand(OnAdd);
            CancelCommand = new DelegateCommand(OnCancel);
        }

        private void OnCancel()
        {
            CloseDialog();
        }

        private void OnAdd()
        {
            AddAction?.Invoke(SerialPortSetting);
        }
    }
}