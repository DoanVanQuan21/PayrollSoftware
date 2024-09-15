using Prism.Mvvm;
using System.Windows.Controls;

namespace InnoSoft.Core.Models
{
    public class MenuSetting : BindableBase
    {
        private string? label;
        private string? viewName;
        private Type? type;
        private UserControl? view;
        private string? iconPath;
        private string? geometry;

        public string? Label { get => label; set => SetProperty(ref label, value); }
        public string? ViewName { get => viewName; set => SetProperty(ref viewName, value); }
        public Type? Type { get => type; set { SetProperty(ref type, value); View = (UserControl)Activator.CreateInstance(Type); } }
        public UserControl? View { get => view; set => SetProperty(ref view, value); }
        public string? IconPath { get => iconPath; set => SetProperty(ref iconPath, value); }
        public string? Geometry { get => geometry; set => SetProperty(ref geometry, value); }
    }
}