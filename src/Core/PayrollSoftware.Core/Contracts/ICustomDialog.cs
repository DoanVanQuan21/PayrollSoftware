using System.Windows.Controls;

namespace PayrollSoftware.Core.Contracts
{
    public interface ICustomDialog
    {
        void Show(UserControl control);

        void Close();
    }
}