using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace gui.Utils
{
    public interface IDialogService
    {
        void Show(string body);
        MessageBoxResult YesNo(string title, string body);
    }

    public class DialogService : IDialogService
    {
        public void Show(string text)
        {
            MessageBox.Show(text);
        }

        public MessageBoxResult YesNo(string title, string text)
        {
            return MessageBox.Show(text, title, MessageBoxButton.YesNo);
        }
    }
}
