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
using System.ComponentModel;

using QuizletNet;

namespace QuizletWidget.Views.Auth
{
    using QuizletWidget.Views.Main;
    using QuizletWidget.Views.Widget;

    public partial class LoginView : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Visibility ShowLoginButton { get; set; } = Visibility.Visible;

        public LoginView()
        {
            InitializeComponent();

            DataContext = this;

            if (OAuth.IsAuthorized)
                OnOAuthResult(true);
            else
                LoadingText.Visibility = Visibility.Hidden;
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            var authView = new OAuthView(OnOAuthResult);
            authView.ShowDialog();
        }

        public void Update()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(""));
        }
        private void OnOAuthResult(bool loggedIn)
        {
            Console.WriteLine("LoginResult : " + loggedIn);

            if (loggedIn)
            {
                ShowLoginButton = Visibility.Hidden;
                LoadingText.Visibility = Visibility.Visible;
                Update();
                LoadMySets();
            }
        }
        private async void LoadMySets()
        {
            Storage.Sets = await Sets.QueryMySets();

            var widgetView = new WidgetView();
            widgetView.Show();

            var mainView = new MainView();
            mainView.Show();

            Close();
        }
    }
}
