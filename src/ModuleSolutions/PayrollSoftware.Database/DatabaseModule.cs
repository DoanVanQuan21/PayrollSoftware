using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.WpfPrism;
using PayrollSoftware.Database.Views;
using Prism.Ioc;
using PayrollSoftware.Database.ViewModels;

namespace PayrollSoftware.Database
{
    public class DatabaseModule : BasePrismModule
    {
        public override string ModuleName => DllName.DatabaseModule;

        public override void Dispose()
        {
        }

        public override void Init()
        {
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public override void Register()
        {
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<SelectionDatabaseViewModel>();
            containerRegistry.RegisterSingleton<AddServerInforViewModel>();
            containerRegistry.RegisterDialog<AddServerInforView>();
        }
    }
}