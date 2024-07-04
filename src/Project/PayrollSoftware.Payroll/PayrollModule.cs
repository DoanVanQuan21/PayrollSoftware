﻿using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Context;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Events;
using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.WpfPrism;
using PayrollSoftware.EntityFramework.Context;
using PayrollSoftware.EntityFramework.Contracts;
using PayrollSoftware.SettingAccount.Views;
using PayrollSoftware.UI.Geometry;
using Prism.Events;
using Prism.Ioc;
using System.Collections.Generic;

namespace PayrollSoftware.Payroll
{
    public class PayrollModule : BasePrismModule
    {
        public override string ModuleName => DllName.PayrollModule;

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
            Ioc.ContainerRegistry.RegisterSingleton<ITaskManagementService, TaskManagementService>();
            Ioc.Resolve<IEventAggregator>().GetEvent<ConnectionDatabaseSuccess>().Publish();
        }
    }
}