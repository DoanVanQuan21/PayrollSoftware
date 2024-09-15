using System.Windows.Controls;

namespace InnoSoft.Core.Contracts
{
    public interface ICustomDialog
    {
        void Show(UserControl control);

        void Close();
    }
}