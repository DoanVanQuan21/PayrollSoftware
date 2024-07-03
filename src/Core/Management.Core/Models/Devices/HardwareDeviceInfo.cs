using System.Management;

namespace Management.Core.Models.Devices
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
            this.DeviceId = GetData("DeviceID");
            this.DeviceName = GetData("Name");
            this.Description = GetData("Description");
            this.Manufacturer = GetData("Manufacturer");
            this.PnpClass = GetData("PnpClass");
            this.Status = GetData("Status");
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