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

    class QuerySetsResponse
    {
        public SingleSet[] sets;
    }

    class QuerySetsResponseConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return typeof(QuerySetsResponse) == objectType;
        }
        public override object ReadJson(
            JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var jary = JArray.Load(reader);
            var sets = new List<SingleSet>();
            var result = new QuerySetsResponse();

            foreach (JObject jobj in jary)
                sets.Add(jobj.ToObject<SingleSet>());
            result.sets = sets.ToArray();

            return result;
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
