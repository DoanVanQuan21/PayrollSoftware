using Management.Core.Models;
using Management.Core.Models.Common;

namespace Management.Core.Contracts
{
    public interface IAppManager
    {
        AppRegion AppRegion { get; set; }
        BootSetting? BootSetting { get; set; }
        List<Gender> Genders { get; }
        void Save();
        void Load();
    }
}