using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

using CefSharp;

using QuizletNet;

namespace QuizletWidget.Views.Auth
{
    using QuizletWidget.Utils;

    public partial class OAuthView : Window
    {
        public delegate void OAuthResultDelegate(bool loggedIn);

        private OAuthResultDelegate callback;

        public OAuthView(OAuthResultDelegate _callback)
        {
            InitializeComponent();

            callback = _callback;

            Browser.Address = OAuth.GetOAuthUri(QuizletApp.ClientId, QuizletApp.RedirectUri);
        }

        private void Browser_FrameLoadStart(object sender, FrameLoadStartEventArgs e)
        {
            
        }

        private async void Browser_LoadError(object sender, LoadErrorEventArgs e)
        {
            if (e.FailedUrl.StartsWith(QuizletApp.RedirectUri) == false)
                return;

            var uri = new Uri(e.FailedUrl);
            var query = HttpUtility.ParseQueryString(uri.Query);

            // Success
            if (query.ContainsKey("error") == false)
            {
                await OAuth.RequestAuthorize(query["code"], QuizletApp.RedirectUri);
            }
            // Failure
            else
            {

            }

            Application.Current.Dispatcher.Invoke(() => {
                callback(OAuth.IsAuthorized);
                Close();
            });  
        }
    }
}
