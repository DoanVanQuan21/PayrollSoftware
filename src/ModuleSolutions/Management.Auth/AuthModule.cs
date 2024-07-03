using Management.Auth.Contracts;
using Management.Auth.Services;
using Management.Auth.ViewModels;
using Management.Core.Constants;
using Management.Core.WpfPrism;
using Prism.Ioc;

namespace Management.Auth
{
    public class AuthModule : BasePrismModule
    {
        public override string ModuleName => DllName.AuthModule;

        public AuthModule() : base()
        {
        }

        public override void Dispose()
        {
            //TODO
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<ILoginService,LoginService>();
            containerRegistry.RegisterSingleton<LoginMedicineViewModel>();

        }

        public override void Init()
        {
            //TODO
        }

        public override void Register()
        {
            //TODO
        }
    }
}