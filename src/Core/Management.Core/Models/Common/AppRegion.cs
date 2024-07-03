using Prism.Mvvm;
using System.Windows.Controls;

namespace Management.Core.Models.Common
{
    public class AppRegion : BindableBase
    {
        private UserControl? mainRegion;
        private UserControl regionPage;

        public AppRegion()
        {
            MainRegion = new UserControl();
        }

        public UserControl? MainRegion
        { get => mainRegion; set { SetProperty(ref mainRegion, value); } }

        public UserControl RegionPage
        { get => regionPage; set { SetProperty(ref regionPage, value); } }
    }
}