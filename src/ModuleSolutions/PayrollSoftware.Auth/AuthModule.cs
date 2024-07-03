using PayrollSoftware.Auth.Contracts;
using PayrollSoftware.Auth.Services;
using PayrollSoftware.Auth.ViewModels;
using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.WpfPrism;
using Prism.Ioc;

namespace PayrollSoftware.Auth
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