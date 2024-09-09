using PayrollSoftware.Core.Context;
using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.Settings.Videos;
using PayrollSoftware.Core.WpfPrism;
using PayrollSoftware.UI.Geometry;
using PayrollSoftware.Video.Contracts;
using PayrollSoftware.Video.Managers;
using PayrollSoftware.Video.Services;
using PayrollSoftware.Video.Views;
using Prism.Ioc;

namespace PayrollSoftware.Video
{
    public class VideoModule : BasePrismModule
    {
        public VideoModule()
        {
        }

        public override string DllName => Core.Constants.DllName.VideoModule;

        public override string ModuleName => "Camera";

        public override void Dispose()
        {
            foreach (var dispose in DisposeActions)
            {
                dispose?.Invoke();
            }
        }

        public override void Init()
        {
            InitMenu();
            var enabledDevices = _settingManager?.BootSetting?.VideoSettings?.Where(item => item.IsEnabled).ToList();
            if (enabledDevices?.Any() == false)
            {
                return;
            }
            InitDevices(enabledDevices);
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
            containerRegistry.RegisterSingleton<ICameraManager, CameraManager>();
            containerRegistry.RegisterSingleton<IImageProcess, ImageProcess>();
        }

        private void InitDevices(IList<VideoSetting> configs)
        {
            var manager = Ioc.Resolve<ICameraManager>();
            if (manager == null)
            {
                return;
            }
            manager.Create(configs);
            DisposeActions.Add(manager.Dispose);
        }

        private void InitMenu()
        {
            var menus = new List<MenuSetting>() {
                new MenuSetting()
                {
                    Type = typeof(VideoPreviewImageView),
                    ViewName = nameof(VideoPreviewImageView),
                    Label = "Video",
                    Geometry = GeometryString.VideoGeometry,
                },new MenuSetting()
                {
                    Type = typeof(AutoLabelView),
                    ViewName = nameof(AutoLabelView),
                    Label = "Auto Label",
                    Geometry = GeometryString.AutoLabelGeometry,
                }
            };
            RootContext.MenuSettings.AddRange(menus);
        }
    }
}