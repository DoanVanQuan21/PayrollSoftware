using InnoSoft.Core.Constants;
using InnoSoft.Core.Context;
using InnoSoft.Core.Contracts;
using InnoSoft.Core.Mvvms;
using Prism.Modularity;
using System.IO;
using System.Reflection;
using System.Windows;

namespace InnoSoft.Shell.Services
{
    internal interface IStartUp
    {
        void Start();

        IStartUp UserProject();
    }

    internal class StartUp : IStartUp
    {
        private readonly IModuleCatalog _moduleCatalog;
        private readonly IModuleManager _moduleManager;
        private readonly IAppManager _settingManager;

        public IStartUp UserProject()
        {
            AddModule(DllName.PayrollModule);
            return this;
        }

        public StartUp()
        {
            _moduleManager = Ioc.Resolve<IModuleManager>();
            _moduleCatalog = Ioc.Resolve<IModuleCatalog>();
            _settingManager = Ioc.Resolve<IAppManager>();
            _settingManager.Load();
        }

        void IStartUp.Start()
        {
            AddModule(DllName.ComportModule);
            AddModule(DllName.AuthModule);
            AddModule(DllName.MonitoringModule);
            AddModule(DllName.DatabaseModule);
            AddModule(DllName.PCANModule);
            AddModule(DllName.LiveChartModule);
            AddModule(DllName.VideoModule);
            LoadModule();
        }

        private void LoadModule()
        {
            foreach (var module in _moduleCatalog.Modules)
            {
                try
                {
                    _moduleManager.LoadModule(module.ModuleName);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    RootContext.Modules[module.ModuleName] = true;
                }
            }
        }

        private static ModuleInfo CreateModuleInfo(Type type, string name)
        {
            string moduleName = name;

            var moduleAttribute = CustomAttributeData.GetCustomAttributes(type).FirstOrDefault(cad => cad.Constructor.DeclaringType.FullName == typeof(ModuleAttribute).FullName);

            if (moduleAttribute != null)
            {
                foreach (CustomAttributeNamedArgument argument in moduleAttribute.NamedArguments)
                {
                    string argumentName = argument.MemberInfo.Name;
                    if (argumentName == "ModuleName")
                    {
                        moduleName = (string)argument.TypedValue.Value;
                        break;
                    }
                }
            }

            ModuleInfo moduleInfo = new(moduleName, type.AssemblyQualifiedName)
            {
                InitializationMode = InitializationMode.OnDemand,
                Ref = type.Assembly.Location,
            };

            return moduleInfo;
        }

        private void AddModule(string dllName)
        {
            var filePath = Path.Combine(Environment.CurrentDirectory, dllName);
            if (!File.Exists(filePath))
            {
                throw new Exception($"DLL {dllName} is not exit");
            }
            if (RootContext.Modules.ContainsKey(dllName))
            {
                return;
            }
            RootContext.Modules.Add(dllName, false);
            var moduleAssembly = AppDomain.CurrentDomain.GetAssemblies().First(item => item.FullName == typeof(IModule).Assembly.FullName) ?? throw new Exception($"DLL {dllName} is not module");
            var IModuleType = moduleAssembly.GetType(typeof(IModule).FullName);
            Assembly assembly = Assembly.LoadFile(filePath);
            var moduleInfos = assembly.GetExportedTypes().Where(IModuleType.IsAssignableFrom).Where(t => t != IModuleType).Where(t => !t.IsAbstract).Select(t => CreateModuleInfo(t, dllName));
            foreach (var moduleInfo in moduleInfos)
            {
                _moduleCatalog.AddModule(moduleInfo);
            }
        }
    }
}