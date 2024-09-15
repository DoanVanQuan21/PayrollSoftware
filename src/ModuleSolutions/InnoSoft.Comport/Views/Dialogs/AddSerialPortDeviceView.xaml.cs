using HandyControl.Controls;
using InnoSoft.Core.Mvvms;
using InnoSoft.Core.Settings.Comports;
using System.Windows.Controls;
using InnoSoft.Comport.ViewModels;

namespace InnoSoft.Comport.Views.Dialogs
{
    /// <summary>
    /// Interaction logic for AddSerialPortDeviceView.xaml
    /// </summary>
    public partial class AddSerialPortDeviceView : UserControl
    {
        private readonly AddSerialPortSettingViewModel _viewModel;
        public AddSerialPortDeviceView()
        {
            InitializeComponent();
            _viewModel = Ioc.Resolve<AddSerialPortSettingViewModel>();
            DataContext = _viewModel;
        }
        public void SetAddAcction(Action<SerialPortSetting> action)
        {
            _viewModel.AddAction = action;
        }
    }
}