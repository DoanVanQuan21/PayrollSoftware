using PayrollSoftware.Core.Constants;

namespace PayrollSoftware.Core.Contracts
{
    public interface IDevice : ICreateable, IOpenable, ICleanUp, ICloseable, IDisposable
    {
        string? DevName { get; set; }
        string? TypeName { get; set; }
        string? Description { get; set; }
        ConnectionStatus ConnectionStatus { get; set; }
        bool IsMonitor { get; set; }
        bool IsConnected { get; set; }
        void Init();
    }
}