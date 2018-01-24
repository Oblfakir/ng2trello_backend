using Newtonsoft.Json;

namespace ng2trello_backend.Models
{
    public class StatusResponse
    {
        public bool Status { get; set; }
        public int? NewItemId { get; set; }
        public string Token { get; set; }

        public static string FalseResponse()
        {
            return JsonConvert.SerializeObject(new StatusResponse
            {
                Status = false
            });
        }

        public static string TrueResponse()
        {
            return JsonConvert.SerializeObject(new StatusResponse
            {
                Status = true
            });
        }
    }
}
