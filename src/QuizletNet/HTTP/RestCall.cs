using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace QuizletNet.HTTP
{
    using QuizletNet.HTTP.Models;

    class RestCall
    {
        public static async Task<T> GetAsync<T>(string uri)
        {
            var http = new HttpClient();

            if (OAuth.IsAuthorized)
                http.DefaultRequestHeaders.Add("Authorization", "Bearer " + OAuth.AccessToken);
            else
                http.DefaultRequestHeaders.Add("Authorization", "Basic " + OAuth.BasicAuthString);

            var response = await http.GetAsync(uri);
            if (response.IsSuccessStatusCode == false)
            {
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                throw new HttpRequestException($"{response.StatusCode}");
            }

            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine(json);

            return JsonConvert.DeserializeObject<T>(json, new JsonConverter[]{
                new QuerySetsResponseConverter()
            });
        }
        public static async Task<T> GetAsync<T>(string uri, Dictionary<string, object> param)
        {
            return await GetAsync<T>(uri + BuildQueryString(param));
        }

        public static async Task<T> PostAsync<T>(string uri, string payload)
        {
            var http = new HttpClient();

            if (OAuth.IsAuthorized)
                http.DefaultRequestHeaders.Add("Authorization", "Bearer " + OAuth.AccessToken);
            else
                http.DefaultRequestHeaders.Add("Authorization", "Basic " + OAuth.BasicAuthString);

            var content = new StringContent(payload);
            var response = await http.PostAsync(uri, content);

            if (response.IsSuccessStatusCode == false)
            {
                Console.WriteLine(uri);
                Console.WriteLine(response.Content.ReadAsStringAsync().Result);
                throw new HttpRequestException($"{response.StatusCode}");
            }
            var json = await response.Content.ReadAsStringAsync();

            Console.WriteLine(json);

            return JsonConvert.DeserializeObject<T>(json);
        }
        public static async Task<T> PostAsync<T>(string uri, Dictionary<string, object> payload)
        {
            return await PostAsync<T>(uri, BuildQueryString(payload));
        }

        private static string BuildQueryString(Dictionary<string, object> param)
        {
            var list = new List<string>();
            foreach (var item in param)
                list.Add(item.Key + "=" + item.Value);
            return string.Join("&", list);
        }
    }
}
