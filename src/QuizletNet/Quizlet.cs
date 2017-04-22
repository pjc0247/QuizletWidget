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

        public static void Initialize()
        {
            LocalStorage.Load();

            OAuth.Initialize();
        }
    }
}
