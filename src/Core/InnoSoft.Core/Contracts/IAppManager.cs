using InnoSoft.Core.Models;
using InnoSoft.Core.Models.Common;

namespace InnoSoft.Core.Contracts
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