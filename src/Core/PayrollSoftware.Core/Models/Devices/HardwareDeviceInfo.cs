using System.Management;

namespace PayrollSoftware.Core.Models.Devices
{
    public class HardwareDeviceInfo
    {
        private PropertyDataCollection? properties;
        public string? DeviceId { get; set; }
        public string? DeviceName { get; set; }
        public string? Description { get; set; }
        public string? Manufacturer { get; set; }
        public string? Status { get; set; }
        public string? PnpClass { get; set; }
        public HardwareDeviceInfo(PropertyDataCollection properties)
        {
            this.properties = properties;
            DeviceId = GetData("DeviceID");
            DeviceName = GetData("Name");
            Description = GetData("Description");
            Manufacturer = GetData("Manufacturer");
            PnpClass = GetData("PnpClass");
            Status = GetData("Status");
        }
        private string? GetData(string nameProp)
        {
            try
            {
                return properties[nameProp].Value?.ToString();
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}