using DryIoc;
using Prism.Ioc;
using System.Diagnostics;

namespace Management.Core.Mvvms
{
    public static class Ioc
    {
        public static IContainer AppContainer { get; set; }

        public static IContainerRegistry ContainerRegistry { get; set; }

        public static IContainerProvider Container { get; set; }

        public static void RegisterSingleton<TFrom, TTo>() where TTo : TFrom
        {
            if (!ContainerRegistry.IsRegistered<TFrom>())
            {
                ContainerRegistry.RegisterSingleton<TFrom, TTo>();
            }
        }

        public static T Resolve<T>()
        {
            try
            {
                var ins = AppContainer.Resolve<T>();
                if (ins == null)
                {
                    Debug.WriteLine($"{typeof(T)} is not register");
                }

                return ins;
            }
            catch
            {
                Debug.WriteLine($"{typeof(T)} is not register");
                return default;
            }
        }
    }
}