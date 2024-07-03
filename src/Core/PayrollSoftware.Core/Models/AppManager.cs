using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Helpers;
using PayrollSoftware.Core.Models.Common;

namespace PayrollSoftware.Core.Models
{
    public class AppManager : IAppManager
    {
        public BootSetting? BootSetting { get; set; }

        public List<Gender> Genders { get; private set; }
        public AppRegion AppRegion { get; set; }

        public AppManager()
        {
            BootSetting = new();
            AppRegion = new();
            InitGenders();
        }

        public void Load()
        {
            BootSetting = FileHelper.Read<BootSetting>(FolderPath.CONFIGURATION, FileName.APP_CONFIG);
        }

        public void Save()
        {
            FileHelper.Save<BootSetting>(FolderPath.CONFIGURATION, FileName.APP_CONFIG, BootSetting);
        }

        private void InitGenders()
        {
            Genders = new List<Gender>() {
                new Gender("Nam",true),
                new Gender("Nữ",false)
            };
        }
    }
}