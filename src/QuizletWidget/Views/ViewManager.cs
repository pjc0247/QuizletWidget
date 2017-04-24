using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletWidget.Views
{
    using QuizletWidget.Views.Auth;
    using QuizletWidget.Views.Main;
    using QuizletWidget.Views.Widget;

    class ViewManager
    {
        public static MainView MainView { get; set; }
        public static LoginView LoginView { get; set; }
        public static WidgetView WidgetView { get; set; }

        public static void CloseAllWindows()
        {
            CloseMainView();
            CloseLoginView();
            CloseWidgetView();
        }

        public static void CloseMainView()
        {
            MainView.Close(); MainView = null;
        }
        public static void CloseLoginView()
        {
            LoginView?.Close(); LoginView = null;
        }
        public static void CloseWidgetView()
        {
            WidgetView?.Close(); WidgetView = null;
        }
    }
}
