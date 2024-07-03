using System.ComponentModel;
using System.Reflection;

namespace PayrollSoftware.UI.CustomControls.PropertyGrid.Helper
{
    public class PropertyHelper
    {
        public static string GetDisplayName(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(DisplayNameAttribute), false);
            if (attributes?.Any() == false)
            {
                return string.Empty;
            }
            var attribute = attributes?.First() as DisplayNameAttribute;
            if (attribute == null)
            {
                return string.Empty;
            }
            return attribute.DisplayName;
        }

        public static string GetCategory(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(CategoryAttribute), false);
            if (attributes?.Any() == false)
            {
                return string.Empty;
            }
            var attribute = attributes?.First() as CategoryAttribute;
            if (attribute == null)
            {
                return string.Empty;
            }
            return attribute.Category;
        }

        public static bool GetBrowsable(PropertyInfo property)
        {
            var attributes = property.GetCustomAttributes(typeof(BrowsableAttribute), false);
            if (attributes?.Any() == false)
            {
                return true;
            }
            return false;
        }
    }
}