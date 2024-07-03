using PayrollSoftware.Core.Models.Devices;
using PayrollSoftware.Core.Settings.PCAN;
using PCANDevice;
using PayrollSoftware.PCan.Contracts;

namespace PayrollSoftware.PCan.Devices
{
    public class PCanDevice : Device, IPCanDevice
    {
        private PCANManager pCANManager;
        private readonly PCANSetting _config;

        public PCanDevice()
        {
            pCANManager = new PCANManager();
        }

        public PCanDevice(PCANSetting config)
        {
            pCANManager = new();
            _config = config;
            DevName = config.DevName;
        }

        public override void Init()
        {
            throw new NotImplementedException();
        }

        public List<ushort> GetAvailabelUsbCan()
        {
            return PCANManager.GetAllAvailable();
        }
    }
}