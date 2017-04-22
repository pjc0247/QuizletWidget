using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletWidget.Views
{
    using QuizletWidget.Views.Main;

    class TrayIcon
    {
        private static System.Windows.Forms.NotifyIcon icon { get; set; }

        public static void RegisterTrayIcon()
        {
            icon = new System.Windows.Forms.NotifyIcon();
            icon.Icon = new System.Drawing.Icon("tray.ico");
            icon.Visible = true;
            icon.Click +=
                delegate (object sender, EventArgs args)
                {
                    OnIconClicked();
                };
        }
        public static void UnregisterTrayIcon()
        {
            icon.Dispose();   
        }

        private static void OnIconClicked()
        {
            var mainView = new MainView();
            mainView.Show();
        }
    }
}
