using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Models.Common;

namespace PayrollSoftware.Core.Contracts
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