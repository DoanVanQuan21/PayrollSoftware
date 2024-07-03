using System.IO;

namespace Management.Core.Constants
{
    public enum ComportDeviceType
    {
        TextCommand,
        ByteCommand
    }

    public enum ConnectionStatus
    {
        CONNECTED,
        DISCONNECTED,
    }
    public enum ModeData
    {
        TEXT,
        BYTE
    }
    public enum DeviceType
    {
        COMPORT,
        VIDEO,
        BTBOX,
        DMM,
        TextCommand,
        ByteCommand
    }

    public enum ModeWrite
    {
        STRING,
        BYTE
    }

    public enum ResultType
    {
        OK,
        NG,
        UNDEFINED
    }

    public enum Role
    {
        Admin,
        User,
        SupperUser,
        SuperAdmin,
    }

    public enum State
    {
        WAITTING,
        SENDING,
        RESPONSED,
        UNDEFINED
    }

    public enum TerminatorCharacter
    {
        CR,
        LF,
    }

    public enum Theme
    {
        Light = 0,
        Dark = 1
    }

    public enum TPCANBaudrate : ushort
    {
        /// <summary>
        /// 1 MBit/s
        /// </summary>
        PCAN_BAUD_1M = 0x0014,

        /// <summary>
        /// 800 KBit/s
        /// </summary>
        PCAN_BAUD_800K = 0x0016,

        /// <summary>
        /// 500 kBit/s
        /// </summary>
        PCAN_BAUD_500K = 0x001C,

        /// <summary>
        /// 250 kBit/s
        /// </summary>
        PCAN_BAUD_250K = 0x011C,

        /// <summary>
        /// 125 kBit/s
        /// </summary>
        PCAN_BAUD_125K = 0x031C,

        /// <summary>
        /// 100 kBit/s
        /// </summary>
        PCAN_BAUD_100K = 0x432F,

        /// <summary>
        /// 95,238 KBit/s
        /// </summary>
        PCAN_BAUD_95K = 0xC34E,

        /// <summary>
        /// 83,333 KBit/s
        /// </summary>
        PCAN_BAUD_83K = 0x852B,

        /// <summary>
        /// 50 kBit/s
        /// </summary>
        PCAN_BAUD_50K = 0x472F,

        /// <summary>
        /// 47,619 KBit/s
        /// </summary>
        PCAN_BAUD_47K = 0x1414,

        /// <summary>
        /// 33,333 KBit/s
        /// </summary>
        PCAN_BAUD_33K = 0x8B2F,

        /// <summary>
        /// 20 kBit/s
        /// </summary>
        PCAN_BAUD_20K = 0x532F,

        /// <summary>
        /// 10 kBit/s
        /// </summary>
        PCAN_BAUD_10K = 0x672F,

        /// <summary>
        /// 5 kBit/s
        /// </summary>
        PCAN_BAUD_5K = 0x7F7F,
    }

    public enum TPCANClock
    {
        CLOCK_20M,
        CLOCK_24M,
        CLOCK_40M,
        CLOCK_80M
    }

    public enum TPCANDatarate : ushort
    {
        /// <summary>
        /// 1 MBit/s
        /// </summary>
        PCAN_DATARATE_2M = 0x0001,

        /// <summary>
        /// 800 KBit/s
        /// </summary>
        PCAN_DATARATE_4M = 0x0002,

        /// <summary>
        /// 500 kBit/s
        /// </summary>
        PCAN_DATARATE_8M = 0x0003,

        /// <summary>
        /// 250 kBit/s
        /// </summary>
        PCAN_DATARATE_10M = 0x0004,
    }

    public class ConnectionString
    {
        public static readonly string DESKTOP_0SMVJQ6 = "Data Source=DESKTOP-0SMVJQ6;Initial Catalog=SchoolManager;Integrated Security=True;Trust Server Certificate=True";
        public static readonly string DESKTOP_NS7SDSM = "Data Source=DESKTOP-NS7SDSM\\SQLEXPRESS;Initial Catalog=SchoolManager;Integrated Security=True";
        public static readonly string DESKTOP_Q183429 = "Data Source=DESKTOP-Q183429\\SQLEXPRESS;Initial Catalog=SchoolManager;Integrated Security=True";
    }

    public class FileName
    {
        public static string APP_CONFIG = "app-config.json";
    }

    public class FolderPath
    {
        public static string CONFIGURATION => Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), Path.Combine("management", "configurations"));
    }

    public class PnpClass
    {
        public static string AUDIO_END_POINT = "AudioEndPoint";
        public static string BATTERY = "Battery";
        public static string BLUETOOTH = "Bluetooth";
        public static string CAMERA = "Camera";
        public static string COMPUTER = "Computer";
        public static string DISK_DRIVE = "DiskDrive";
        public static string DISPLAY = "Display";
        public static string FIRMWARE = "Firmware";
        public static string HID_CLASS = "HIDClass";
        public static string IMAGE = "Image";
        public static string KEYBOARD = "Keyboard";
        public static string MEDIA = "Media";
        public static string PORTS = "Ports";
        public static string PRINTER = "Printer";
        public static string USB = "USB";
    }

    public class Visibility
    {
        public static readonly string COLLAPSED = "Collapsed";
        public static readonly string HIDDEN = "Hidden";
        public static readonly string VISIBLE = "Visible";
    }
}