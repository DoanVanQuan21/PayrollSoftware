using InnoSoft.Core.WpfPrism;
using Prism.Ioc;
using InnoSoft.Auth.Contracts;
using InnoSoft.Auth.Services;
using InnoSoft.Auth.ViewModels;

namespace InnoSoft.Auth
{
    public class AuthModule : BasePrismModule
    {
        public override string DllName => Core.Constants.DllName.AuthModule;

        public override string ModuleName => "Auth";

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
            containerRegistry.RegisterSingleton<ILoginService, LoginService>();
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