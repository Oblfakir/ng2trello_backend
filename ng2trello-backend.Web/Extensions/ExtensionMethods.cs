using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace ng2trello_backend.Web
{
    public static class ExtensionMethods
    {
        public static Dictionary<string, string> BodyToDictionary(this JObject value)
        {
            return value?.ToObject<Dictionary<string, string>>();
        }
    }
}
