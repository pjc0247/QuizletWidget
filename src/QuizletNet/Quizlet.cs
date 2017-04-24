using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletNet
{
    public class Quizlet
    {
        public static string Endpoint = "https://api.quizlet.com";
        public static string Username { get; internal set; }

        public static bool Initialize()
        {
            LocalStorage.Load();

            OAuth.Initialize();

            return OAuth.IsAuthorized;
        }

        public static void RemoveLoginData()
        {
            LocalStorage.Reset();
            OAuth.Reset();
        }
    }
}
