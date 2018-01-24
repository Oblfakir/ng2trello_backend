using Newtonsoft.Json;

namespace ng2trello_backend.Models.Serializable
{
    public abstract class SerializableBase
    {
        public string Serialize()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
