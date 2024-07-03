
using System;
using System.Collections.Generic;
using System.Threading;

namespace PCANDevice
{
    /// <summary>
    /// Event data for OnConnect, OnDisconnect
    /// </summary>
    public class StatusChanged : EventArgs
    {
        public bool status { get; set; }
    }

    /// <summary>
    /// Represents a generic PCAN status
    /// </summary>
    public enum PCANStatus
    {
        OK = 0x00,
        Connected = 0x01,
        Error = 0xff
    };

    /// <summary>
    /// Delegate of ReceiveCallback functions
    /// </summary>
    public delegate int PCANCallback(object[] args);

    /// <summary>
    /// Abstraction Layer of PCANBasic 
    /// </summary>
    public class PCANManager
    {
        public bool isConnected = false;
        public event EventHandler<StatusChanged> Connected;
        public event EventHandler<StatusChanged> Disconnected;
        public List<PCANCallback> receiveCallbacks = new List<PCANCallback>();
        private bool isFDEnabled = false;
        private ushort device = 0x00;
        private Thread InstanceCaller;
        public bool IsTransmitting = false;
        private volatile bool autoReceiveStatus = false;
        public volatile object TransmissionLock = new object();
        private volatile object thread_lock = new object();
        private volatile object thread_send_lock = new object();
        private volatile object thread_lock_callbacks = new object();
        private static readonly ushort[] m_HandlesArray = new ushort[]
{
                PCANBasic.PCAN_ISABUS1,
                PCANBasic.PCAN_ISABUS2,
                PCANBasic.PCAN_ISABUS3,
                PCANBasic.PCAN_ISABUS4,
                PCANBasic.PCAN_ISABUS5,
                PCANBasic.PCAN_ISABUS6,
                PCANBasic.PCAN_ISABUS7,
                PCANBasic.PCAN_ISABUS8,
                PCANBasic.PCAN_DNGBUS1,
                PCANBasic.PCAN_PCIBUS1,
                PCANBasic.PCAN_PCIBUS2,
                PCANBasic.PCAN_PCIBUS3,
                PCANBasic.PCAN_PCIBUS4,
                PCANBasic.PCAN_PCIBUS5,
                PCANBasic.PCAN_PCIBUS6,
                PCANBasic.PCAN_PCIBUS7,
                PCANBasic.PCAN_PCIBUS8,
                PCANBasic.PCAN_PCIBUS9,
                PCANBasic.PCAN_PCIBUS10,
                PCANBasic.PCAN_PCIBUS11,
                PCANBasic.PCAN_PCIBUS12,
                PCANBasic.PCAN_PCIBUS13,
                PCANBasic.PCAN_PCIBUS14,
                PCANBasic.PCAN_PCIBUS15,
                PCANBasic.PCAN_PCIBUS16,
                PCANBasic.PCAN_USBBUS1,
                PCANBasic.PCAN_USBBUS2,
                PCANBasic.PCAN_USBBUS3,
                PCANBasic.PCAN_USBBUS4,
                PCANBasic.PCAN_USBBUS5,
                PCANBasic.PCAN_USBBUS6,
                PCANBasic.PCAN_USBBUS7,
                PCANBasic.PCAN_USBBUS8,
                PCANBasic.PCAN_USBBUS9,
                PCANBasic.PCAN_USBBUS10,
                PCANBasic.PCAN_USBBUS11,
                PCANBasic.PCAN_USBBUS12,
                PCANBasic.PCAN_USBBUS13,
                PCANBasic.PCAN_USBBUS14,
                PCANBasic.PCAN_USBBUS15,
                PCANBasic.PCAN_USBBUS16,
                PCANBasic.PCAN_PCCBUS1,
                PCANBasic.PCAN_PCCBUS2,
                PCANBasic.PCAN_LANBUS1,
                PCANBasic.PCAN_LANBUS2,
                PCANBasic.PCAN_LANBUS3,
                PCANBasic.PCAN_LANBUS4,
                PCANBasic.PCAN_LANBUS5,
                PCANBasic.PCAN_LANBUS6,
                PCANBasic.PCAN_LANBUS7,
                PCANBasic.PCAN_LANBUS8,
                PCANBasic.PCAN_LANBUS9,
                PCANBasic.PCAN_LANBUS10,
                PCANBasic.PCAN_LANBUS11,
                PCANBasic.PCAN_LANBUS12,
                PCANBasic.PCAN_LANBUS13,
                PCANBasic.PCAN_LANBUS14,
                PCANBasic.PCAN_LANBUS15,
                PCANBasic.PCAN_LANBUS16,
};

        private TPCANMsg _CANMsg = new() { MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD };
        private TPCANMsg _CANMsgExt = new() { MSGTYPE = TPCANMessageType.PCAN_MESSAGE_EXTENDED };
        private TPCANMsgFD _CANMsgFD = new() { MSGTYPE = TPCANMessageType.PCAN_MESSAGE_STANDARD };
        private TPCANMsgFD _CANMsgFDExt = new() { MSGTYPE = TPCANMessageType.PCAN_MESSAGE_EXTENDED };

        public static List<ushort> GetAllAvailable()
        {
            try
            {
                List<ushort> availableInterfaces = new();

                for (int i = 0; i < m_HandlesArray.Length; i++)
                {
                    if (m_HandlesArray[i] > PCANBasic.PCAN_DNGBUS1)
                    {
                        TPCANStatus stsResult = PCANBasic.GetValue(m_HandlesArray[i], TPCANParameter.PCAN_CHANNEL_CONDITION, out uint iBuffer, sizeof(uint));
                        if ((stsResult == TPCANStatus.PCAN_ERROR_OK) && ((iBuffer & PCANBasic.PCAN_CHANNEL_AVAILABLE) == PCANBasic.PCAN_CHANNEL_AVAILABLE))
                        {
                            availableInterfaces.Add(m_HandlesArray[i]);
                        }
                    }
                }
                return availableInterfaces;
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static bool IsPCANFD(ushort handle)
        {
            TPCANChannelInformation[] BUFF = new TPCANChannelInformation[1];
            PCANBasic.GetValue(handle, TPCANParameter.PCAN_HARDWARE_NAME, BUFF);
            return BUFF[0].device_name.ToLower().Contains("fd");
        }

        public PCANStatus Connect(TPCANConfig config)
        {
            TPCANStatus stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN;

            lock (thread_lock)
            {
                stsResult = PCANBasic.Initialize(config.DevId, config.Baudrate);
                stsResult = PCANBasic.FilterMessages(config.DevId, (uint)config.FilterLow, (uint)config.FilterHigh, TPCANMode.PCAN_MODE_EXTENDED);
                device = stsResult == TPCANStatus.PCAN_ERROR_OK ? config.DevId : (ushort)0x00;
            }
            OnConnect(new StatusChanged() { status = true });
            isFDEnabled = false;
            return stsResult == TPCANStatus.PCAN_ERROR_OK ? PCANStatus.OK : PCANStatus.Error;
        }

        private long ClockToValue(TPCANClock clock)
        {
            switch (clock)
            {
                case TPCANClock.CLOCK_20M:
                    return 20000000;
                case TPCANClock.CLOCK_40M:
                    return 40000000;
                case TPCANClock.CLOCK_80M:
                    return 80000000;
                case TPCANClock.CLOCK_24M:
                    return 24000000;
            }

            return 80000000;
        }

        /// <summary>
        ///CANFDConfiguration
        /// </summary>
        /// <param name="config">The configuration.</param>
        /// <returns></returns>
        private string CANFDConfiguration(TPCANConfig config)
        {
            return $"f_clock = {ClockToValue(config.Clock)}, nom_brp = {config.NomBrp}, nom_tseg1 = {config.NomTseg1}, nom_tseg2 = {config.NomTseg2}, nom_sjw = {config.NomSjw}, data_brp = {config.DataBrp}, data_tseg1 = {config.DataTseg1}, data_tseg2 = {config.DataTseg2}, data_sjw = {config.DataSjw}";
        }

        private bool IsCanFDBaudrateValid(TPCANBaudrate baudrate)
        {
            var validBaud = new List<TPCANBaudrate> { TPCANBaudrate.PCAN_BAUD_250K, TPCANBaudrate.PCAN_BAUD_500K, TPCANBaudrate.PCAN_BAUD_1M };
            return validBaud.Contains(baudrate);
        }
        public PCANStatus ConnectFD(TPCANConfig config)
        {
            TPCANStatus stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN;
            try
            {
                lock (thread_lock)
                {
                    if (IsPCANFD(config.DevId) == false)
                    {
                        return PCANStatus.Error;
                    }

                    if (!IsCanFDBaudrateValid(config.Baudrate))
                    {
                        return PCANStatus.Error;
                    }
                    string configuration = CANFDConfiguration(config);

                    if (string.IsNullOrEmpty(configuration))
                    {
                        return PCANStatus.Error;
                    }

                    stsResult = PCANBasic.InitializeFD(config.DevId, configuration);

                    stsResult = PCANBasic.FilterMessages(config.DevId, (uint)config.FilterLow, (uint)config.FilterHigh, TPCANMode.PCAN_MODE_EXTENDED);
                    device = stsResult == TPCANStatus.PCAN_ERROR_OK ? config.DevId : (ushort)0x00;
                }
                OnConnect(new StatusChanged() { status = true });
                isFDEnabled = true;
                return stsResult == TPCANStatus.PCAN_ERROR_OK ? PCANStatus.OK : PCANStatus.Error;
            }
            catch (Exception)
            {
                return PCANStatus.Error;
            }
        }
        public void Reset()
        {
            PCANBasic.Reset(device);
        }

        public void GetStatus()
        {
            PCANBasic.GetStatus(device);
        }
        protected virtual void OnConnect(StatusChanged e)
        {
            Connected?.Invoke(this, e);
        }

        protected virtual void OnDisconnect(StatusChanged e)
        {
            Disconnected?.Invoke(this, e);
        }

        public PCANStatus Disconnect()
        {
            TPCANStatus stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN;
            try
            {
                lock (thread_lock)
                {
                    DeactivateAutoReceive();
                    stsResult = PCANBasic.Uninitialize(device);
                    device = 0x00;
                }
                OnDisconnect(new StatusChanged() { status = false });
                return stsResult == TPCANStatus.PCAN_ERROR_OK ? PCANStatus.OK : PCANStatus.Error;
            }
            catch (Exception)
            {
                device = 0x00;
                return PCANStatus.Error;
            }
        }

        public int IsConnected()
        {
            return device;
        }

        public static int GetDataLength(TPCANMsgFD msg)
        {
            if (((byte)msg.DLC) <= 8)
            {
                return msg.DLC;
            }

            switch (msg.DLC)
            {
                case 9:
                    return 12;
                case 10:
                    return 16;
                case 11:
                    return 20;
                case 12:
                    return 24;
                case 13:
                    return 32;
                case 14:
                    return 48;
                case 15:
                    return 64;
                default:
                    return 0;
            }
        }

        public PCANStatus SendFrame(int canID, int DLC, byte[] data)
        {
            IsTransmitting = true;
            lock (thread_send_lock)
            {
                Thread.SpinWait(600);
                TPCANStatus stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN;
                try
                {
                    byte[] tmp = new byte[8];
                    for (int i = 0; i < data.Length; i++)
                        tmp[i] = data[i];


                    _CANMsg.ID = (uint)canID;
                    _CANMsg.LEN = (byte)DLC;
                    _CANMsg.DATA = tmp;

                    lock (thread_lock)
                    {
                        stsResult = PCANBasic.Write(device, ref _CANMsg);
                    }
                    Thread.SpinWait(100);
                    IsTransmitting = false;
                    return stsResult == TPCANStatus.PCAN_ERROR_OK ? PCANStatus.OK : PCANStatus.Error;
                }
                catch (Exception)
                {
                    Thread.SpinWait(6000);
                    IsTransmitting = false;
                    return PCANStatus.Error;
                }
            }
        }

        public PCANStatus SendFrameFD(int canID, int DLC, byte[] data)
        {
            IsTransmitting = true;
            lock (thread_send_lock)
            {
                Thread.SpinWait(6000);
                TPCANStatus stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN;
                try
                {
                    byte[] tmp = new byte[64];
                    for (int i = 0; i < data.Length; i++)
                    {
                        tmp[i] = data[i];
                    }

                    _CANMsgFD.ID = (uint)canID;

                    if (((byte)DLC) <= 8)
                    {
                        _CANMsgFD.DLC = (byte)DLC;
                    }
                    else if (((byte)DLC) <= 12)
                    {
                        _CANMsgFD.DLC = 9;
                    }
                    else if (((byte)DLC) <= 16)
                    {
                        _CANMsgFD.DLC = (byte)10;
                    }
                    else if (((byte)DLC) <= 20)
                    {
                        _CANMsgFD.DLC = (byte)11;
                    }
                    else if (((byte)DLC) <= 24)
                    {
                        _CANMsgFD.DLC = (byte)12;
                    }
                    else if (((byte)DLC) <= 32)
                    {
                        _CANMsgFD.DLC = (byte)13;
                    }
                    else if (((byte)DLC) <= 48)
                    {
                        _CANMsgFD.DLC = (byte)14;
                    }
                    else if (((byte)DLC) <= 64)
                    {
                        _CANMsgFD.DLC = (byte)15;
                    }

                    _CANMsgFD.DATA = tmp;
                    _CANMsgFD.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_FD | TPCANMessageType.PCAN_MESSAGE_STANDARD;
                    lock (thread_lock)
                    {
                        stsResult = PCANBasic.WriteFD(device, ref _CANMsgFD);
                    }
                    Thread.SpinWait(100);
                    IsTransmitting = false;
                    return stsResult == TPCANStatus.PCAN_ERROR_OK ? PCANStatus.OK : PCANStatus.Error;
                }
                catch (Exception)
                {
                    Thread.SpinWait(6000);
                    IsTransmitting = false;
                    return PCANStatus.Error;
                }
            }
        }

        public PCANStatus SendFrameFDExt(int canID, int DLC, byte[] data)
        {
            IsTransmitting = true;
            lock (thread_send_lock)
            {
                Thread.SpinWait(6000);
                TPCANStatus stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN;
                try
                {
                    byte[] tmp = new byte[64];
                    for (int i = 0; i < data.Length; i++)
                    {
                        tmp[i] = data[i];
                    }

                    _CANMsgFD.ID = (uint)canID;

                    if (((byte)DLC) <= 8)
                    {
                        _CANMsgFD.DLC = (byte)DLC;
                    }
                    else if (((byte)DLC) <= 12)
                    {
                        _CANMsgFD.DLC = 9;
                    }
                    else if (((byte)DLC) <= 16)
                    {
                        _CANMsgFD.DLC = (byte)10;
                    }
                    else if (((byte)DLC) <= 20)
                    {
                        _CANMsgFD.DLC = (byte)11;
                    }
                    else if (((byte)DLC) <= 24)
                    {
                        _CANMsgFD.DLC = (byte)12;
                    }
                    else if (((byte)DLC) <= 32)
                    {
                        _CANMsgFD.DLC = (byte)13;
                    }
                    else if (((byte)DLC) <= 48)
                    {
                        _CANMsgFD.DLC = (byte)14;
                    }
                    else if (((byte)DLC) <= 64)
                    {
                        _CANMsgFD.DLC = (byte)15;
                    }

                    _CANMsgFD.DATA = tmp;
                    _CANMsgFD.MSGTYPE = TPCANMessageType.PCAN_MESSAGE_FD | TPCANMessageType.PCAN_MESSAGE_EXTENDED;
                    lock (thread_lock)
                    {
                        stsResult = PCANBasic.WriteFD(device, ref _CANMsgFD);
                    }
                    Thread.SpinWait(100);
                    IsTransmitting = false;
                    return stsResult == TPCANStatus.PCAN_ERROR_OK ? PCANStatus.OK : PCANStatus.Error;
                }
                catch (Exception)
                {
                    Thread.SpinWait(6000);
                    IsTransmitting = false;
                    return PCANStatus.Error;
                }
            }
        }

        public PCANStatus SendFrameExt(int canID, int DLC, byte[] data)
        {
            IsTransmitting = true;
            lock (thread_send_lock)
            {
                Thread.SpinWait(6000);
                TPCANStatus stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN;
                try
                {
                    byte[] tmp = new byte[8];
                    for (int i = 0; i < data.Length; i++)
                    {
                        tmp[i] = data[i];
                    }

                    _CANMsgExt.ID = (uint)canID;
                    _CANMsgExt.LEN = (byte)DLC;
                    _CANMsgExt.DATA = tmp;

                    lock (thread_lock)
                    {
                        stsResult = PCANBasic.Write(device, ref _CANMsgExt);
                    }
                    Thread.SpinWait(100);
                    IsTransmitting = false;
                    return stsResult == TPCANStatus.PCAN_ERROR_OK ? PCANStatus.OK : PCANStatus.Error;
                }
                catch (Exception)
                {
                    Thread.SpinWait(6000);
                    IsTransmitting = false;
                    return PCANStatus.Error;
                }
            }
        }

        public PCANStatus RetrieveFrame(out TPCANMsg CANMsg, out TPCANTimestamp CANTimeStamp)
        {
            TPCANStatus stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN;

            CANMsg = new TPCANMsg();

            try
            {
                lock (thread_lock)
                {
                    stsResult = PCANBasic.Read(device, out CANMsg, out CANTimeStamp);
                }

                return CANMsg.MSGTYPE == TPCANMessageType.PCAN_MESSAGE_STATUS ? PCANStatus.Error : (stsResult != TPCANStatus.PCAN_ERROR_QRCVEMPTY ? PCANStatus.OK : PCANStatus.Error);
            }
            catch (Exception)
            {
                CANMsg = new TPCANMsg();
                CANTimeStamp = new TPCANTimestamp();
                return PCANStatus.Error;
            }
        }

        public PCANStatus RetrieveFrameFD(out TPCANMsgFD CANMsg, out ulong CANTimeStamp)
        {
            TPCANStatus stsResult = TPCANStatus.PCAN_ERROR_UNKNOWN;

            CANMsg = new TPCANMsgFD();

            try
            {
                lock (thread_lock)
                {
                    stsResult = PCANBasic.ReadFD(device, out CANMsg, out CANTimeStamp);
                }

                return CANMsg.MSGTYPE == TPCANMessageType.PCAN_MESSAGE_STATUS ? PCANStatus.Error : (stsResult != TPCANStatus.PCAN_ERROR_QRCVEMPTY ? PCANStatus.OK : PCANStatus.Error);
            }
            catch (Exception)
            {
                CANMsg = new TPCANMsgFD();
                CANTimeStamp = 0;
                return PCANStatus.Error;
            }
        }

        public void AddReceiveCallback(PCANCallback callback)
        {
            receiveCallbacks.Add(callback);
        }

        public void RemoveReceiveCallback(PCANCallback callback)
        {
            int index_found = -1;

            lock (thread_lock_callbacks)
            {
                for (int i = (receiveCallbacks.Count - 1); i >= 0; i--)
                {
                    if (receiveCallbacks[i] == callback)
                    {
                        index_found = i;
                        break;
                    }
                }
                if (index_found != -1)
                {
                    receiveCallbacks.RemoveAt(index_found);
                }
            }
        }

        public void ActivateAutoReceive()
        {
            if (isFDEnabled == false)
            {
                InstanceCaller = new Thread(new ThreadStart(AutoReceive));
            }
            else
            {
                InstanceCaller = new Thread(new ThreadStart(AutoReceiveFD));
            }
            InstanceCaller.Priority = ThreadPriority.AboveNormal;
            autoReceiveStatus = true;
            InstanceCaller.Start();
        }

        public void DeactivateAutoReceive()
        {
            autoReceiveStatus = false;
        }

        private void AutoReceive()
        {
            List<PCANCallback> toRemoveCallbacks = new();
            bool isreceived = false;
            while (autoReceiveStatus)
            {
                while (RetrieveFrame(out TPCANMsg msg, out TPCANTimestamp timestamp) == PCANStatus.OK)
                {
                    if (autoReceiveStatus == false)
                    {
                        receiveCallbacks.Clear();
                        return;
                    }
                    isreceived = true;
                    lock (thread_lock_callbacks)
                    {
                        try
                        {
                            for (int i = (receiveCallbacks.Count - 1); i >= 0; i--)
                            {
                                if (receiveCallbacks[i](new object[] { msg, timestamp }) != 0x00)
                                {
                                    toRemoveCallbacks.Add(receiveCallbacks[i]);
                                }
                            }
                            if (toRemoveCallbacks.Count != 0)
                            {
                                for (int i = (toRemoveCallbacks.Count - 1); i >= 0; i--)
                                {
                                    receiveCallbacks.Remove(toRemoveCallbacks[i]);
                                }
                                toRemoveCallbacks.Clear();
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                if (isreceived == true)
                {
                    isreceived = false;
                }
                else
                {
                    Thread.Sleep(2);
                }
            }
            receiveCallbacks.Clear();
        }

        private void AutoReceiveFD()
        {
            List<PCANCallback> toRemoveCallbacks = new();
            bool isreceived = false;
            while (autoReceiveStatus)
            {
                while (RetrieveFrameFD(out TPCANMsgFD msg, out ulong timestamp) == PCANStatus.OK)
                {
                    if (autoReceiveStatus == false)
                    {
                        receiveCallbacks.Clear();
                        return;
                    }
                    isreceived = true;
                    lock (thread_lock_callbacks)
                    {
                        try
                        {
                            for (int i = (receiveCallbacks.Count - 1); i >= 0; i--)
                            {
                                if (receiveCallbacks[i](new object[] { msg, timestamp }) != 0x00)
                                {
                                    toRemoveCallbacks.Add(receiveCallbacks[i]);
                                }
                            }
                            if (toRemoveCallbacks.Count != 0)
                            {
                                for (int i = (toRemoveCallbacks.Count - 1); i >= 0; i--)
                                {
                                    receiveCallbacks.Remove(toRemoveCallbacks[i]);
                                }
                                toRemoveCallbacks.Clear();
                            }
                        }
                        catch (Exception)
                        {

                        }
                    }
                }
                if (isreceived == true)
                {
                    isreceived = false;
                }
                else
                {
                    Thread.Sleep(2);
                }
            }
            receiveCallbacks.Clear();
        }
    }
}
