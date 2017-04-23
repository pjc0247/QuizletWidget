using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletNet
{
    using QuizletNet.Models;
    using QuizletNet.HTTP;
    using QuizletNet.HTTP.Models;

    public class User
    {
        public static async Task<UserData> QueryUser(string username)
        {
            try
            {
                var response = await RestCall.GetAsync<QueryUserResponse>(
                    Quizlet.Endpoint + $"/2.0/users/{username}");

                return response.user;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public static async Task<UserData> QueryMe(string username)
        {
            return await QueryUser(Quizlet.Username);
        }
    }
}
