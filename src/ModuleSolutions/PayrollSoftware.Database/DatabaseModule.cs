using PayrollSoftware.Core.WpfPrism;
using PayrollSoftware.Database.ViewModels;
using PayrollSoftware.Database.Views;
using Prism.Ioc;

namespace PayrollSoftware.Database
{
    public class DatabaseModule : BasePrismModule
    {
        public override string DllName => Core.Constants.DllName.DatabaseModule;

        public override string ModuleName => "Database";

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