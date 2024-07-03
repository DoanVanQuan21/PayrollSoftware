using PayrollSoftware.Core.Helpers;
using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Models.Devices.Sessions;
using PayrollSoftware.Core.Settings.Comports;
using PayrollSoftware.Comport.Contracts;

namespace PayrollSoftware.Comport.Devices
{
    internal class ByteCommandDevice : ComportDevice, IByteCommandDevice
    {
        public ByteCommandDevice() : base()
        {
        }

        public ByteCommandDevice(SerialPortSetting config) : base(config)
        {
        }

        protected override async Task FillCurrentSession()
        {
            if (CurrentSession == null)
            {
                //TODO
                return;
            }
            var byteSession = CurrentSession as ByteSession;
            if (byteSession == null)
            {
                //TODO
                return;
            }
            try
            {
                var (isOK, responses) = await CheckProcessResponses(byteSession);
                if (!isOK || responses?.Any() == false)
                {
                    byteSession.Result = ResultType.NG;
                    return;
                }
                byteSession.Result = ResultType.OK;
                byteSession.ResponseBytes.Clear();
                byteSession.ResponseBytes.AddRange(responses);
            }
            catch (Exception ex)
            {
                byteSession.Result = ResultType.NG;
                byteSession.ResponseBytes.Clear();
            }
        }

        protected override void GetRawData()
        {
            var size = _comport.BytesToRead;
            if (size == null)
            {
                return;
            }
            var buffer = new byte[size];
            _ = _comport.Read(buffer, 0, size);
            if (buffer?.Length < 0)
            {
                return;
            }
            RawDatas.Enqueue(buffer.ToList());
            DataReceived?.Invoke(this, buffer);
        }

        protected override async Task ProcessRawData()
        {
            while (!_tokenSource.IsCancellationRequested)
            {
                if (RawDatas == null || !RawDatas.Any())
                {
                    await Task.Delay(20);
                    continue;
                }
                _ = RawDatas.TryDequeue(out var rawData);
                if (rawData == null)
                {
                    continue;
                }
                ProcessedResspones.Enqueue(rawData);
                await Task.Delay(100);
            }
        }

        protected override Task Write(Session session)
        {
            return Task.Factory.StartNew(() =>
            {
                if (_comport?.IsOpen == false)
                {
                    //TODO
                    return;
                }
                var byteSession = session as ByteSession;
                if (byteSession == null)
                {
                    //TODO
                    return;
                }
                _comport.Write(byteSession.CommandBytes.ToArray(), 0, byteSession.CommandBytes.Count);
            });
        }

        private async Task<(bool, List<byte>)> CheckProcessResponses(Session session)
        {
            var responses = new List<byte>();
            var res = await Untils.WaitAsync(session.TimeOut, () =>
            {
                if (ProcessedResspones.Count <= 0)
                {
                    return false;
                }
                var isDequeued = ProcessedResspones.TryDequeue(out var result);
                if (!isDequeued)
                {
                    return false;
                }
                var res = result as List<byte>;
                if (res?.Any() == false)
                {
                    return false;
                }
                responses.AddRange(res);
                return true;
            });
            return (res, responses);
        }
    }
}