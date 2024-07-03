using System.Windows.Controls;

namespace Management.Core.Contracts
{
    public interface ICustomDialog
    {
        void Show(UserControl control);

        void Close();
    }
}