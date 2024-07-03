using HandyControl.Controls;
using Management.Core.Contracts;
using System.Windows.Controls;

namespace Management.Core.Services
{
    public class CustomDialog : ICustomDialog
    {
        private Dialog _dialog;

        public CustomDialog()
        {
            _dialog = new Dialog();
        }

        public void Close()
        {
            _dialog.Close();
        }

        public void Show(UserControl control)
        {
            _dialog = Dialog.Show(control);
        }
    }
}