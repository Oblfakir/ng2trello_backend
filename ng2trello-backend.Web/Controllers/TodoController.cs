using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ng2trello_backend.BLL.Implementations;
using ng2trello_backend.BLL.Interfaces;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities.Response;
using ng2trello_backend.Entities.Serializable;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ng2trello_backend.Controllers
{
    [Authorize(AuthenticationSchemes = "Bearer", Policy = "registered")]
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly ITodoService _service;
        public TodoController(ITodolistRepository repository)
        {
            _service = new TodoService(repository);
        }

        [HttpPost("{todolistid}")]
        public string Post(int todolistid, [FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerTodo>>();
            if (dict != null)
            {
                return JsonConvert.SerializeObject(new StatusResponse
                {
                    Status = true,
                    NewItemId = _service.AddTodo(todolistid, dict["todo"])
                });
            }
            return StatusResponse.FalseResponse();
        }

        [HttpPut("{todolistid}/{id}")]
        public string Put(int todolistid, int id, [FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerTodo>>();
            if (dict != null)
            {
                _service.ChangeTodo(todolistid, id, dict["todo"]);
                return StatusResponse.TrueResponse();
            }
            return StatusResponse.FalseResponse();
        }

        [HttpDelete("{todolistid}/{id}")]
        public string Delete(int todolistid, int id)
        {
            _service.DeleteTodo(todolistid, id);
            return StatusResponse.TrueResponse();
        }
    }
}
