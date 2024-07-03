using Prism.Modularity;

namespace Management.Core.Contracts
{
    public interface ICustomModule : IModule, IDisposable
    {
        void Init();
        void Register();
    }
}