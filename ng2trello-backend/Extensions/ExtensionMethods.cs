using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ng2trello_backend.Extensions
{
    public static class ExtensionMethods
    {
        public static string Serialize<T>(this IEnumerable<T> list)
        {
            return JsonConvert.SerializeObject(list);
        }

        public static Dictionary<string, string> BodyToDictionary(this JObject value)
        {
            return value.ToObject<Dictionary<string, string>>();
        }

        //public static Dictionary<string, string> BodyToDictionary(this JObject value)
        //{
        //    var requestDict = value.ToObject<Dictionary<string, object>>();
        //    return (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, string>>();
        //}
    }
}
