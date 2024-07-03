using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Context;
using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.WpfPrism;
using PayrollSoftware.LiveChart.Views;
using PayrollSoftware.UI.Geometry;
using Prism.Ioc;

namespace PayrollSoftware.LiveChart
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