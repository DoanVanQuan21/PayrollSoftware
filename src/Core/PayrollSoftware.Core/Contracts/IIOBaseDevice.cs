using PayrollSoftware.Core.Models.Devices.Sessions;

namespace PayrollSoftware.Core.Contracts
{
    public interface IIOBaseDevice
    {
        Task<Session> SendAndWait(Session session, int retry = 5);
    }
}