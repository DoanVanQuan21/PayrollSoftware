using Management.Core.Constants;
using Management.Core.WpfPrism;
using Management.Database.ViewModels;
using Management.Database.Views;
using Prism.Ioc;

namespace Management.Database
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