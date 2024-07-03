using Management.Core.Constants;
using Management.Core.Context;
using Management.Core.Models;
using Management.Core.WpfPrism;
using Management.LiveChart.Views;
using Management.UI.Geometry;
using Prism.Ioc;

namespace Management.LiveChart
{
    public class LiveChartModule : BasePrismModule
    {
        public override string ModuleName => DllName.LiveChartModule;

        public LiveChartModule()
        {
            
        }
        public override void Dispose()
        {
        }

        public override void Init()
        {
            InitMenu();
        }

        public override void OnInitialized(IContainerProvider containerProvider)
        {
             Init();
        }

        public override void Register()
        {
        }

        public override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        private void InitMenu()
        {
            var menus = new List<MenuSetting>() {
                new MenuSetting()
                {
                    Type = typeof(LiveChartView),
                    ViewName = nameof(LiveChartView),
                    Label = "Live chart",
                    Geometry = GeometryString.ChartMultipleGeometry,
                }
            };
            RootContext.MenuSettings.AddRange(menus);
        }
    }
}