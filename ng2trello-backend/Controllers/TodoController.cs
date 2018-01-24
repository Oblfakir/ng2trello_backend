using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Extensions;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Implementations;
using ng2trello_backend.Services.Interfaces;
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
      var requestDict = value.ToObject<Dictionary<string, object>>();
      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, SerTodo>>();
      if (dict != null)
      {
        return JsonConvert.SerializeObject(new StatusResponse
        {
          Status = true,
          NewItemId = _service.AddTodo(todolistid, dict["todo"])
        });
      }
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = false
      });
//      var requestDict = value.ToObject<Dictionary<string, object>>();
//      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, JObject>>();
//      var todoobj = dict?["todo"].ToObject<Dictionary<string, string>>();
//      if (todoobj != null)
//      {
//          var todo = new SerTodo
//          {
//            Id = 0,
//            Status = bool.Parse(todoobj["Status"]),
//            Text = todoobj["Text"]
//          };
//        _service.AddTodo(todolistid, todo);
//        return JsonConvert.SerializeObject(new Status {status = "true"});
//      }
//      return JsonConvert.SerializeObject(new Status {status = "false"});
    }

    [HttpPut("{todolistid}/{id}")]
    public string Put(int todolistid, int id, [FromBody] JObject value)
    {
      var requestDict = value.ToObject<Dictionary<string, object>>();
      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, SerTodo>>();
      if (dict != null)
      {
        _service.ChangeTodo(todolistid, id, dict["todo"]);
        return JsonConvert.SerializeObject(new StatusResponse
        {
          Status = true
        });
      }
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = false
      });
//      var requestDict = value.ToObject<Dictionary<string, object>>();
//      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, JObject>>();
//      var todoobj = dict?["todo"].ToObject<Dictionary<string, string>>();
//      if (todoobj != null)
//      {
//        var todo = new SerTodo
//        {
//          Id = 0,
//          Status = bool.Parse(todoobj["Status"]),
//          Text = todoobj["Text"]
//        };
//        _service.ChangeTodo(todolistid, id, todo);
//        return JsonConvert.SerializeObject(new Status {status = "true"});
//      }
//      return JsonConvert.SerializeObject(new Status {status = "false"});
    }

    [HttpDelete("{todolistid}/{id}")]
    public string Delete(int todolistid, int id)
    {
      _service.DeleteTodo(todolistid, id);
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = true
      });
    }
  }
}
