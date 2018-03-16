using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ng2trello_backend.BLL.Interfaces;
using ng2trello_backend.Entities.Response;
using ng2trello_backend.Entities.Serializable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ng2trello_backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "registered")]
    [Route("api/[controller]")]
    public class ContentController : Controller
    {
        private readonly IContentService _service;

        public ContentController(IContentService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Get()
        {
            return _service.GetAllContent();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _service.GetContentByCardId(id);
        }

        [HttpPost]
        public string Post([FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerContent>>();
            if (dict != null)
            {
                return JsonConvert.SerializeObject(new StatusResponse
                {
                    Status = true,
                    NewItemId = _service.AddContent(dict["content"])
                });
            }
            return StatusResponse.FalseResponse();
        }

        [HttpPut("{id}")]
        public string Post(int id, [FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerContent>>();
            if (dict != null)
            {
                _service.ChangeContent(id, dict["content"]);
                return StatusResponse.TrueResponse();
            }
            return StatusResponse.FalseResponse();
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _service.DeleteContent(id);
            return StatusResponse.TrueResponse();
        }
    }
}
