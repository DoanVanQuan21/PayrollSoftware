using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Editors;
using PayrollSoftware.Core.Settings;
using System.ComponentModel;

namespace PayrollSoftware.Core.Settings.Comports
{
    public class SerialPortSetting : BaseSetting
    {
        private int baudrate;
        private List<byte>? connectionBytes;
        private string? connectionString;
        private string? expectedString;
        private string? port = "COM 1";
        private TerminatorCharacter terminatorCharacter;

        public SerialPortSetting() : base()
        {
        }

        public SerialPortSetting(Guid id) : base(id)
        {
        }

        [Editor(typeof(BaudratePropertyEditor), typeof(BaudratePropertyEditor))]
        public int Baudrate
        {
            get { return baudrate; }
            set { SetProperty(ref baudrate, value); }
        }

        [Browsable(false)]
        public List<byte>? ConnectionBytes
        {
            get { return connectionBytes; }
            set { SetProperty(ref connectionBytes, value); }
        }

        [Browsable(false)]
        public string? ConnectionString
        {
            get { return connectionString; }
            set { SetProperty(ref connectionString, value); }
        }

        [Browsable(false)]
        public string? ExpectedString
        {
            get { return expectedString; }
            set { SetProperty(ref expectedString, value); }
        }

        [Editor(typeof(PortNamePropertyEditor), typeof(PortNamePropertyEditor))]
        [DisplayName("Port")]
        public string? Port
        {
            get { return port; }
            set { SetProperty(ref port, value); }
        }
        public TerminatorCharacter TerminatorCharacter { get => terminatorCharacter; set => SetProperty(ref terminatorCharacter, value); }
    }
}