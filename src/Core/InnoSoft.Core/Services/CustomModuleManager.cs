using InnoSoft.Core.Contracts;

namespace InnoSoft.Core.Services
{
    public class CustomModuleManager : ICustomModuleManager
    {
        public List<ICustomModule> CustomModules { get; private set; }

        public CustomModuleManager()
        {
            CustomModules = new();
        }
    }
}