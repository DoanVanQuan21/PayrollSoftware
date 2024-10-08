﻿using InnoSoft.Core.Constants;
using InnoSoft.Core.Models.Common;
using InnoSoft.Core.Models.TaskManagement;
using InnoSoft.Core.Settings.Comports;
using InnoSoft.Core.Settings.PCAN;
using InnoSoft.Core.Settings.Videos;
using Prism.Mvvm;
using System.Collections.ObjectModel;

namespace InnoSoft.Core.Models
{
    public class BootSetting : BindableBase
    {
        private Theme currentTheme = Theme.Dark;
        private User currentUser;
        private bool isSelectedDatabase = false;
        private string? version;

        public BootSetting()
        {
            ID = Guid.NewGuid();
            Version = "SOFT_VER_1";
            SerialPortSettings = new();
            PCANSettings = new();
            VideoSettings = new() { new() };
            ServerInfors = new();
            CurrentServerInfor = new();
        }

        public ServerInfor CurrentServerInfor { get; set; }

        public Theme CurrentTheme
        { get => currentTheme; set { SetProperty(ref currentTheme, value); } }

        public User CurrentUser
        { get => currentUser; set { SetProperty(ref currentUser, value); } }

        public Guid ID { get; set; }

        public bool IsSelectedDatabase
        {
            get => isSelectedDatabase;
            set { SetProperty(ref isSelectedDatabase, value); }
        }

        public ObservableCollection<PCANSetting> PCANSettings { get; set; }

        public ObservableCollection<SerialPortSetting> SerialPortSettings { get; set; }
        public ObservableCollection<VideoSetting> VideoSettings { get; set; }

        public ObservableCollection<ServerInfor> ServerInfors { get; set; }

        public string? Version
        {
            get { return version; }
            set { SetProperty(ref version, value); }
        }
    }
}