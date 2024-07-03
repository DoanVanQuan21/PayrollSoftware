using Management.Core.Constants;
using Management.Core.Context;
using Management.Core.Contracts;
using Management.Core.Models;
using Management.Core.Mvvms;
using Management.Core.Settings.Videos;
using Management.Core.WpfPrism;
using Management.UI.Geometry;
using Management.Video.Contracts;
using Management.Video.Managers;
using Management.Video.Services;
using Management.Video.Views;
using Prism.Ioc;

namespace Management.Video
{
    public class VideoModule : BasePrismModule
    {
        public VideoModule()
        {
        }

        public override string ModuleName => DllName.VideoModule;

        public override void Dispose()
        {
            foreach(var dispose in DisposeActions)
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