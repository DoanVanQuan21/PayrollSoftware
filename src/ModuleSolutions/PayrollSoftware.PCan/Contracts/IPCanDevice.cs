namespace PayrollSoftware.PCan.Contracts
{
    public interface IPCanDevice
    {
        List<ushort> GetAvailabelUsbCan();
    }
}