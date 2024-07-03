using Prism.Modularity;

namespace PayrollSoftware.Core.Contracts
{
    public interface ICustomModule : IModule, IDisposable
    {
        void Init();
        void Register();
    }
}