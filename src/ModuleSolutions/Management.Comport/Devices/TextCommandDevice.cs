using Management.Comport.Contracts;
using Management.Core.Helpers;
using Management.Core.Models.Devices.Sessions;
using Management.Core.Settings.Comports;

namespace Management.Comport.Devices
{
    internal class TextCommandDevice : ComportDevice, ITextCommandDevice
    {
        public TextCommandDevice() : base()
        {
        }

        public TextCommandDevice(SerialPortSetting config) : base(config)
        {
        }

        protected override async Task FillCurrentSession()
        {
            if (CurrentSession == null)
            {
                //TODO
                return;
            }
            var textSession = CurrentSession as TextSession;
            if (textSession == null)
            {
                //TODO
                return;
            }
            var (isOK, response) = await CheckProcessResponses(textSession);
            if (!isOK || string.IsNullOrEmpty(response))
            {
                textSession.Result = Core.Constants.ResultType.NG;
                return;
            }
            textSession.Result = Core.Constants.ResultType.OK;
            textSession.Response = response;
        }

        protected override void GetRawData()
        {
            var response = _comport?.ReadExisting();
            if (string.IsNullOrEmpty(response))
            {
                return;
            }
            RawDatas?.Enqueue(response);
            DataReceived?.Invoke(this, response);
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
                var chars = rawData.ToString().ToCharArray();
                var data = "";
                foreach (var c in chars)
                {
                    data = $"{data}{c.ToString()}";
                    if (CompareTerminator(c))
                    {
                        ProcessedResspones.Enqueue(rawData);
                        break;
                    }
                }
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
                var textSession = session as TextSession;
                if (textSession == null)
                {
                    return;
                }
                _comport?.WriteLine(textSession.Command);
            });
        }
        private async Task<(bool, string)> CheckProcessResponses(Session session)
        {
            var response = string.Empty;
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
                var res = (string)result;
                if (string.IsNullOrEmpty(res))
                {
                    return false;
                }
                response = res;
                return true;
            });
            return (res, response);
        }
        private bool CompareTerminator(char compareValue)
        {
            switch (_config.TerminatorCharacter)
            {
                case Core.Constants.TerminatorCharacter.CR:
                    return compareValue == '\r';

                case Core.Constants.TerminatorCharacter.LF:
                    return compareValue == '\n';

                default:
                    return false;
            }
        }
    }
}