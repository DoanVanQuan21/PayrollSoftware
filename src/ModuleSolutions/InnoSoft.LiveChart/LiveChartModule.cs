using InnoSoft.Core.Context;
using InnoSoft.Core.Models;
using InnoSoft.Core.WpfPrism;
using InnoSoft.LiveChart.Views;
using InnoSoft.UI.Geometry;
using Prism.Ioc;

namespace InnoSoft.LiveChart
{
    public class LiveChartModule : BasePrismModule
    {
        public override string DllName => Core.Constants.DllName.LiveChartModule;

        public override string ModuleName => "Chart";

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