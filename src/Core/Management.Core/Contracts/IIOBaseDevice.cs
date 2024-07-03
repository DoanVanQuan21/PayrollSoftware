using Management.Core.Models.Devices.Sessions;

namespace Management.Core.Contracts
{
    public interface IIOBaseDevice
    {
        Task<Session> SendAndWait(Session session, int retry = 5);
    }
}