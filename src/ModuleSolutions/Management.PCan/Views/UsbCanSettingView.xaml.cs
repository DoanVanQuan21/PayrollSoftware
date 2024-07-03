﻿using Management.Core.Mvvms;
using Management.PCan.ViewModels;
using System.Windows.Controls;

namespace Management.PCan.Views
{
    /// <summary>
    /// Interaction logic for UsbCanSettingView.xaml
    /// </summary>
    public partial class UsbCanSettingView : UserControl
    {
        private UsbCanSettingViewModel _viewModel;

        public UsbCanSettingView()
        {
            InitializeComponent();
            _viewModel = Ioc.Resolve<UsbCanSettingViewModel>();
            DataContext = _viewModel;
        }

        private void ComboBox_DropDownOpened(object sender, EventArgs e)
        {
            _viewModel.LoadingCANDevicesCommand.Execute(null);
        }
    }
}