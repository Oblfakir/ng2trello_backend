using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ng2trello_backend.BLL.Implementations.Extensions
{
    public static class ExtensionMethods
    {
        public static string Serialize<T>(this IEnumerable<T> list)
        {
            return JsonConvert.SerializeObject(list);
        }

        public static Dictionary<string, string> BodyToDictionary(this JObject value)
        {
            return value?.ToObject<Dictionary<string, string>>();
        }
    }
}
