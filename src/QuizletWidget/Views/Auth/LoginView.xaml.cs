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
    using QuizletWidget.Views.Main;
    using QuizletWidget.Views.Widget;

    public partial class LoginView : Window
    {
        public Visibility ShowLoginButton { get; set; } = Visibility.Visible;

        public LoginView()
        {
            InitializeComponent();

            DataContext = this;

            Quizlet.Initialize();
            OAuth.SetAuthData(QuizletApp.ClientId, QuizletApp.ClientSecret);

            if (OAuth.IsAuthorized)
            {
                ShowLoginButton = Visibility.Hidden;
                LoadingText.Visibility = Visibility.Visible;
                OnOAuthResult(true);
            }
            else
            {
                LoadingText.Visibility = Visibility.Hidden;
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
                LoadMySets();
        }

        private async void LoadMySets()
        {
            Storage.Sets = await Sets.QueryMySets();

            var mainView = new MainView();
            mainView.Show();
            Close();
        }
    }
}
