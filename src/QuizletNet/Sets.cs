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
        public static async Task<SingleSet> QuerySet(string id)
        {
            try
            {
                var response = await RestCall.GetAsync<QuerySingleSetResponse>(
                    Quizlet.Endpoint + $"/2.0/sets/{id}");

                return response.set;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }

        public static async Task<SingleSet[]> QueryUserSets(string username)
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
                throw e;
            }
        }
        public static async Task<SingleSet[]> QueryUserFavoriteSets(string username)
        {
            try
            {
                var response = await RestCall.GetAsync<QuerySetsResponse>(
                    Quizlet.Endpoint + $"/2.0/users/{username}/favorites");

                return response.sets;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
        public static async Task<SingleSet[]> QueryClassSets(string classId)
        {
            try
            {
                var response = await RestCall.GetAsync<QuerySetsResponse>(
                    Quizlet.Endpoint + $"/2.0/classes/{classId}/sets");

                return response.sets;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw e;
            }
        }
        public static async Task<SingleSet[]> QueryMySets()
        {
            return await QueryUserSets(Quizlet.Username);
        }
    }
}
