namespace PayrollSoftware.Core.Contracts
{
    public interface ICustomModuleManager
    {
        List<ICustomModule> CustomModules { get; }
    }
}