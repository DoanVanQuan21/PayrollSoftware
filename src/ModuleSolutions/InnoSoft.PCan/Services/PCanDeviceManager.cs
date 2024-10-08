﻿using InnoSoft.Core.Settings.PCAN;
using System.Collections.ObjectModel;
using InnoSoft.PCan.Contracts;
using InnoSoft.PCan.Devices;

namespace InnoSoft.PCan.Services
{
    public class PCanDeviceManager : IPcanDeviceManager
    {
        public ObservableCollection<PCanDevice>? Devices { get; set; } = new();

        public Task<bool> AddDevice(PCANSetting config)
        {
            throw new NotImplementedException();
        }

        public void Create(params object[] objs)
        {
            if (objs[0] is not IList<PCANSetting> configs)
            {
                return;
            }
            foreach (var config in configs)
            {
                Devices?.Add(new PCanDevice(config));
            }
        }

        public PCanDevice? GetDevice(string name)
        {
            return Devices.FirstOrDefault(p => p.DevName == name);
        }

        public Task<bool> RemoveDevice(PCanDevice device)
        {
            throw new NotImplementedException();
        }
    }
}