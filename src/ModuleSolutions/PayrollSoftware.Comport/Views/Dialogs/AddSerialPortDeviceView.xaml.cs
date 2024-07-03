using HandyControl.Controls;
using PayrollSoftware.Comport.ViewModels;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.Settings.Comports;
using System.Windows.Controls;

namespace PayrollSoftware.Comport.Views.Dialogs
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