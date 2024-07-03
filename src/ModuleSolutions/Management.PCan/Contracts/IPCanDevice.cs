namespace Management.PCan.Contracts
{
    public interface IPCanDevice
    {
        List<ushort> GetAvailabelUsbCan();
    }
}