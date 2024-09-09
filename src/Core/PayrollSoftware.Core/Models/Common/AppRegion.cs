using Prism.Mvvm;
using System.Windows.Controls;

namespace PayrollSoftware.Core.Models.Common
{
    public class AppRegion : BindableBase
    {
        private UserControl? mainRegion;
        private UserControl regionPage;

        private string title;

        public AppRegion()
        {
            MainRegion = new UserControl();
        }

        public UserControl? MainRegion
        { get => mainRegion; set { SetProperty(ref mainRegion, value); } }

        public UserControl RegionPage
        { get => regionPage; set { SetProperty(ref regionPage, value); } }

        public string Title
        {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
    }
}