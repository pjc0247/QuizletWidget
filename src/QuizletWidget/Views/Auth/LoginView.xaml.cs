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

using QuizletNet;

namespace QuizletWidget.Views.Auth
{
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();

            Quizlet.Initialize();
            OAuth.SetAuthData(QuizletApp.ClientId, QuizletApp.ClientSecret);

            if (OAuth.IsAuthorized)
            {
                OnOAuthResult(true);
            }
        }

        private async void Test()
        {
            var result = await Sets.QuerySets("quizlette10562");

            foreach (var set in result)
            {
                Console.WriteLine(set.id);
            }
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var authView = new OAuthView(OnOAuthResult);
            authView.ShowDialog();
        }

        private void OnOAuthResult(bool loggedIn)
        {
            Console.WriteLine("LoginResult : " + loggedIn);

            if (loggedIn)
                Test();
        }
    }
}
