using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace QuizletNet.HTTP.Models
{
    using QuizletNet.Models;

    public class QueryUserResponse
    {
        public UserData user;
    }

    #region CONVERTERS
    class QueryUserResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(QueryUserResponse) == objectType;
        }
        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var result = new QueryUserResponse()
            {
                user = JObject.Load(reader).ToObject<UserData>()
            };
            return result;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
    #endregion
}
