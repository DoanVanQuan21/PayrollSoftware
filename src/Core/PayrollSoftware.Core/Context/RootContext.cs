using PayrollSoftware.Core.Models;
using System.Windows;

namespace PayrollSoftware.Core.Context
{
    public class RootContext
    {
        public static readonly List<MenuSetting> MenuSettings = new();
        public static readonly Dictionary<string, bool> Modules = new();
        public static Window CurrentWindow = new();
    }
}