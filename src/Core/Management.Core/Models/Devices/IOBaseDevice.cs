using HandyControl.Tools.Extension;
using Management.Core.Contracts;
using Management.Core.Helpers;
using Management.Core.Models.Devices.Sessions;
using System.Collections.Concurrent;

namespace Management.Core.Models.Devices
{
    public abstract class IOBaseDevice : Device, IIOBaseDevice
    {
        public EventHandler<object> DataReceived;
        protected Session? CurrentSession;
        protected ConcurrentQueue<Session> ProcessSessions;
        protected ConcurrentQueue<object> ProcessedResspones;
        protected ConcurrentQueue<object> RawDatas;
        protected CancellationTokenSource _tokenSource;

        public IOBaseDevice()
        {
            _tokenSource = new();
            RawDatas = new();
            ProcessedResspones = new();
            ProcessSessions = new();
            Task.Factory.StartNew(ProccessCommand, _tokenSource.Token);
            Task.Factory.StartNew(ProcessRawData, _tokenSource.Token);
        }

        protected void AddRawDatas(object data)
        {
            RawDatas.Enqueue(data);
        }

        protected abstract Task ProcessRawData();

        public virtual async Task<Session> SendAndWait(Session session, int retry = 5)
        {
            var cloneSession = session.CastTo<Session>();
            for (int i = 0; i < retry; i++)
            {
                ProcessSessions.Enqueue(cloneSession);
                var res = await Untils.WaitAsync(cloneSession.TimeOut, () => cloneSession.Result != Constants.ResultType.UNDEFINED);
                if (res)
                {
                    return cloneSession;
                }
            }
            cloneSession.Result = Constants.ResultType.NG;
            return cloneSession;
        }

        protected virtual Task FillCurrentSession()
        {
            return Task.CompletedTask;
        }

        protected virtual async Task ProccessCommand()
        {
            while (!_tokenSource.IsCancellationRequested)
            {
                if (ProcessSessions.Count <= 0)
                {
                    await Task.Delay(100);
                    continue;
                }
                var isDequeued = ProcessSessions.TryDequeue(out CurrentSession);
                if (!isDequeued || CurrentSession == null)
                {
                    continue;
                }
                await Write(CurrentSession);
                await FillCurrentSession();
                CurrentSession = null;
                await Task.Delay(100);
            }
        }

        protected virtual Task Write(Session session)
        {
            return Task.CompletedTask;
        }
    }
}