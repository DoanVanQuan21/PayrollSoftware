using InnoSoft.Core.Models.Devices.Sessions;

namespace InnoSoft.Core.Contracts
{
    public interface IIOBaseDevice
    {
        Task<Session> SendAndWait(Session session, int retry = 5);
    }
}