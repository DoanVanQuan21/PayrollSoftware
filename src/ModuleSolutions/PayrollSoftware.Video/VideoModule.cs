using PayrollSoftware.Core.Constants;
using PayrollSoftware.Core.Context;
using PayrollSoftware.Core.Contracts;
using PayrollSoftware.Core.Models;
using PayrollSoftware.Core.Mvvms;
using PayrollSoftware.Core.Settings.Videos;
using PayrollSoftware.Core.WpfPrism;
using PayrollSoftware.UI.Geometry;
using Management.Video.Views;
using Prism.Ioc;
using PayrollSoftware.Video.Contracts;
using PayrollSoftware.Video.Managers;
using PayrollSoftware.Video.Services;

namespace PayrollSoftware.Video
{
    public class VideoModule : BasePrismModule
    {
        public VideoModule()
        {
        }

        public override string ModuleName => DllName.VideoModule;

        public override void Dispose()
        {
            foreach (var dispose in DisposeActions)
            {
                dispose?.Invoke();
            }
        }

        public override void Init()
        {
            var enabledDevices = _settingManager?.BootSetting?.VideoSettings?.Where(item => item.IsEnabled).ToList();
            if (enabledDevices?.Any() == false)
            {
                return;
            }
            InitDevices(enabledDevices);
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
                }
            };
            RootContext.MenuSettings.AddRange(menus);
        }
    }
}