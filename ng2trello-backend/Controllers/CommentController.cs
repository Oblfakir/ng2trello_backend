using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ng2trello_backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "registered")]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        private readonly ICommentService _service;

        public CommentController(ICommentService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Get()
        {
            return _service.GetAllComments();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _service.GetCommentById(id);
        }

        [HttpPost]
        public string Post([FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerComment>>();
            if (dict != null)
            {
                var newItemId = _service.AddComment(dict["comment"]);
                return JsonConvert.SerializeObject(new StatusResponse
                {
                    Status = true,
                    NewItemId = newItemId
                });
            }
            return StatusResponse.FalseResponse();
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerComment>>();
            if (dict != null)
            {
                _service.ChangeComment(id, dict["comment"]);
                return StatusResponse.TrueResponse();
            }
            return StatusResponse.FalseResponse();
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _service.DeleteComment(id);
            return StatusResponse.FalseResponse();
        }
    }
}
