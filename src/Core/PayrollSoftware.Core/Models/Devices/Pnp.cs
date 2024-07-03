using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Contracts;
using Prism.Mvvm;

namespace PayrollSoftware.Core.Models.Devices
{
    public abstract class Pnp : BindableBase, IDevice
    {
        private ConnectionStatus connectionStatus;
        private string? description;
        private DeviceType deviceType;
        private string? devName;
        private bool isEnable = true;
        private bool isMonitor;
        private string? pnpClass;
        private string? pnpID;
        private string? typeName;
        private bool isConnected = false;
        public Pnp()
        {
            IsConnected = false;
        }
        public ConnectionStatus ConnectionStatus
        {
            get => connectionStatus; set
            {
                SetProperty(ref connectionStatus, value);
            }
        }

        public string? Description
        { get => description; set { SetProperty(ref description, value); } }

        public DeviceType DeviceType
        {
            get { return deviceType; }
            set { SetProperty(ref deviceType, value); }
        }

        public string? DevName
        { get => devName; set { SetProperty(ref devName, value); } }

        public Guid ID { get; set; }

        public bool IsEnable { get => isEnable; set => SetProperty(ref isEnable, value); }

        public bool IsMonitor
        { get => isMonitor; set { SetProperty(ref isMonitor, value); } }

        public string? PnpClass
        {
            get { return pnpClass; }
            set { SetProperty(ref pnpClass, value); }
        }

        public string? PnpID
        {
            get { return pnpID; }
            set { SetProperty(ref pnpID, value); }
        }

        public string? TypeName
        { get => typeName; set { SetProperty(ref typeName, value); } }

        public bool IsConnected
        {
            get => isConnected; set
            {
                SetProperty(ref isConnected, value);
                if (isConnected)
                {
                    ConnectionStatus = ConnectionStatus.CONNECTED;
                    return;
                }
                ConnectionStatus = ConnectionStatus.DISCONNECTED;
            }
        }

        public virtual void CleanUp()
        {
        }

        public virtual void Close()
        {
        }

        public virtual void Create()
        {
        }

        public virtual void Dispose()
        {
        }

        public virtual void Init()
        { }

        public virtual void Open()
        { }
    }
}