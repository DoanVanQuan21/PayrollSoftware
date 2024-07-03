using PayrollSoftware.Core.Constants;

namespace PayrollSoftware.Core.Settings.PCAN
{
    public class PCANSetting : BaseSetting
    {
        public TPCANClock Clock { get; set; }
        public TPCANBaudrate Baudrate { get; set; }
        public TPCANDatarate DataRate { get; set; }
        public bool IsCanFD { get; set; }

        public ushort DevId { get; set; }

        public int NomBrp { get; set; }
        public int NomTseg1 { get; set; }
        public int NomTseg2 { get; set; }
        public int NomSjw { get; set; }

        public int DataBrp { get; set; }
        public int DataTseg1 { get; set; }
        public int DataTseg2 { get; set; }
        public int DataSjw { get; set; }

        public int FilterLow { get; set; }
        public int FilterHigh { get; set; }

        public PCANSetting()
        {
            FilterHigh = 0x1FFFFFFF;
            FilterLow = 0x000;
        }
    }
}