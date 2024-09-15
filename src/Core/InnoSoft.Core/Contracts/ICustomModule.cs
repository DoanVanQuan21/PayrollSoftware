using Prism.Modularity;

namespace InnoSoft.Core.Contracts
{
    public interface ICustomModule : IModule, IDisposable
    {
        string ModuleName { get; }
        void Init();
        void Register();
    }
}