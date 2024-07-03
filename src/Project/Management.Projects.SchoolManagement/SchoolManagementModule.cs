using Management.Core.Constants;
using Management.Core.Context;
using Management.Core.Contracts;
using Management.Core.Events;
using Management.Core.Models;
using Management.Core.Mvvms;
using Management.Core.WpfPrism;
using Management.EntityFramework.Context;
using Management.EntityFramework.Contracts;
using Management.SchoolManagement.SettingAccount.Views;
using Management.UI.Geometry;
using Prism.Events;
using Prism.Ioc;
using System.Collections.Generic;

namespace Management.Projects.SchoolManagement
{
    public class SchoolManagenetModule : BasePrismModule
    {
        public override string ModuleName => DllName.SchoolManagementModule;

        public SchoolManagenetModule()
        {
            Ioc.Resolve<IEventAggregator>().GetEvent<RequiredConnectionDatabase>().Subscribe(RegisterDatabase);
        }

        public override void Dispose()
        {
        }

        public override void Init()
        {
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
            InitMenu();
        }

        public override void Register()
        {
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            if (Ioc.Resolve<IAppManager>().BootSetting.IsSelectedDatabase)
            {
                RegisterDatabase();
            }
        }

        private void InitMenu()
        {
            var menu = new List<MenuSetting>
            {
                new()
                {
                    ViewName = nameof(SettingAccountView),
                    Type = typeof(SettingAccountView),
                    Label = "Cài đặt tài khoản",
                    Geometry = GeometryString.UserSettingGeometry,
                }
            };
            RootContext.MenuSettings.AddRange(menu);
        }

        private void RegisterDatabase()
        {
            Ioc.ContainerRegistry.RegisterSingleton<ISchoolManagerServer, SchoolManagerServer>();
            Ioc.Resolve<IEventAggregator>().GetEvent<ConnectionDatabaseSuccess>().Publish();
        }
    }
}