using PayrollSoftware.Core.Context;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Events;
using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.WpfPrism;
using PayrollSoftware.EntityFramework.Context;
using PayrollSoftware.EntityFramework.Contracts;
using PayrollSoftware.ProjectManagement.Views;
using PayrollSoftware.SettingAccount.Views;
using PayrollSoftware.TaskManagement.Services;
using PayrollSoftware.TaskManagement.Services.Contracts;
using PayrollSoftware.TaskManagement.Views;
using PayrollSoftware.UI.Geometry;
using Prism.Events;
using Prism.Ioc;
using System.Collections.Generic;

namespace PayrollSoftware.Payroll
{
    public class PayrollModule : BasePrismModule
    {
        public override string DllName => Core.Constants.DllName.PayrollModule;

        public override string ModuleName => "Main project";

        public PayrollModule()
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
            containerRegistry.RegisterSingleton<ITaskService, TaskService>();
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
                },
                 new()
                {
                    ViewName = nameof(ProjectsView),
                    Type = typeof(ProjectsView),
                    Label = "Quản lý dự án",
                    Geometry = GeometryString.DocumentGeometry,
                },
                 new()
                {
                    ViewName = nameof(TasksView),
                    Type = typeof(TasksView),
                    Label = "Danh sách công việc",
                    Geometry = GeometryString.DocumentGeometry,
                }
            };
            RootContext.MenuSettings.AddRange(menu);
        }

        private void RegisterDatabase()
        {
            Ioc.ContainerRegistry.RegisterSingleton<ITaskManagementService, TaskManagementService>();
            Ioc.Resolve<IEventAggregator>().GetEvent<ConnectionDatabaseSuccess>().Publish();
        }
    }
}