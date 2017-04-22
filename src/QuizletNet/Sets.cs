using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuizletNet
{
    using QuizletNet.HTTP;
    using QuizletNet.HTTP.Models;
    using QuizletNet.Models;

    public class Sets
    {
        public static async Task<SingleSet[]> QuerySets(string username)
        {
            try
            {
                var response = await RestCall.GetAsync<QuerySetsResponse>(
                    Quizlet.Endpoint + $"/2.0/users/{username}/sets");

                return response.sets;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
        }
        public static async Task<SingleSet[]> QueryMySets()
        {
            return await QuerySets(Quizlet.UserId);
        }
    }
}
