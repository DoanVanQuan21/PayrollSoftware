using Prism.Modularity;

namespace PayrollSoftware.Core.Contracts
{
    public interface ICustomModule : IModule, IDisposable
    {
        string ModuleName { get; }
        void Init();
        void Register();
    }
}