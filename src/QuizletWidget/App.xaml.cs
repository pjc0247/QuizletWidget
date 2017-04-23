using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using QuizletNet;

namespace QuizletWidget
{
    using QuizletWidget.Config;
    using QuizletWidget.Views;

    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            AppConfig.Load();
            Quizlet.Initialize();
            OAuth.SetAuthData(QuizletApp.ClientId, QuizletApp.ClientSecret);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            TrayIcon.UnregisterTrayIcon();
        }
    }
}
