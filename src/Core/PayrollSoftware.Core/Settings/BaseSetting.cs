using PayrollSoftware.Core.Constants;
using Prism.Mvvm;
using System.ComponentModel;

namespace PayrollSoftware.Core.Settings
{
    public class BaseSetting : BindableBase
    {
        private DeviceType deviceType;
        private string devName;
        private bool isEnabled;
        private bool isMonitor;

        public BaseSetting()
        {
            ID = Guid.NewGuid();
        }

        public BaseSetting(Guid id)
        {
            ID = id == Guid.Empty ? Guid.NewGuid() : id;
        }

        [DisplayName("Loại thiết bị")]
        public DeviceType DeviceType { get => deviceType; set => SetProperty(ref deviceType, value); }

        [DisplayName("Tên thiết bị")]
        public string DevName
        { get => devName; set { SetProperty(ref devName, value); } }

        [Browsable(false)]
        public Guid ID { get; set; }

        [DisplayName("Bật thiết bị")]
        public bool IsEnabled
        {
            get { return isEnabled; }
            set { SetProperty(ref isEnabled, value); }
        }

        [Browsable(false)]
        public bool IsMonitor
        {
            get { return isMonitor; }
            set { SetProperty(ref isMonitor, value); }
        }
    }
}