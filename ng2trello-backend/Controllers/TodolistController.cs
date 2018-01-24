using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ng2trello_backend.Database.Interfaces;
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
  public class TodolistController : Controller
  {
    private readonly ITodolistService _service;
    public TodolistController(ITodolistRepository repository)
    {
      _service = new TodolistService(repository);
    }

    [HttpGet]
    public string Get()
    {
      return _service.GetAllTodolists();
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
      return _service.GetTodolistById(id);
    }

    [HttpPost]
    public string Post( [FromBody] JObject value)
    {
      var requestDict = value.ToObject<Dictionary<string, object>>();
      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, SerTodolist>>();
      if (dict != null)
      {
        return JsonConvert.SerializeObject(new StatusResponse
        {
          Status = true,
          NewItemId = _service.AddTodolist(dict["todolist"])
        });
      }
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = false
      });

//      var requestDict = value.ToObject<Dictionary<string, object>>();
//      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, JObject>>();
//      var todoobj = dict?["todolist"].ToObject<Dictionary<string, JObject>>();
//      if (todoobj != null)
//      {
//        var todos = todoobj["Todos"].ToObject<Dictionary<string, JObject>>();
//        var todolistTodos = new List<SerTodo>();
//        foreach (var todo1 in todos)
//        {
//          var newTodo = todo1.Value.ToObject<Dictionary<string, string>>();
//          todolistTodos.Add(new SerTodo
//          {
//            Id = int.Parse(newTodo["Id"]),
//            Text = newTodo["Text"],
//            Status = bool.Parse(newTodo["Status"])
//          });
//        }
//        var todo = new SerTodolist
//        {
//          Id = 0,
//          Todos = todolistTodos,
//          Title = todoobj["Title"].ToString()
//        };
//        _service.AddTodolist(todo);
//        return JsonConvert.SerializeObject(new Status {status = "true"});
//      }
//      return JsonConvert.SerializeObject(new Status {status = "false"});
    }

    [HttpPut("{id}")]
    public string Put(int id,  [FromBody] JObject value)
    {
      var requestDict = value.ToObject<Dictionary<string, object>>();
      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, SerTodolist>>();
      if (dict != null)
      {
        _service.ChangeTodolist(id, dict["todolist"]);
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
//      var todoobj = dict?["todolist"].ToObject<Dictionary<string, JObject>>();
//      if (todoobj != null)
//      {
//        var todos = todoobj["Todos"].ToObject<Dictionary<string, JObject>>();
//        var todolistTodos = new List<SerTodo>();
//        foreach (var todo1 in todos)
//        {
//          var newTodo = todo1.Value.ToObject<Dictionary<string, string>>();
//          todolistTodos.Add(new SerTodo
//          {
//            Id = int.Parse(newTodo["Id"]),
//            Text = newTodo["Text"],
//            Status = bool.Parse(newTodo["Status"])
//          });
//        }
//        var todo = new SerTodolist
//        {
//          Id = 0,
//          Todos = todolistTodos,
//          Title = todoobj["Title"].ToString()
//        };
//        _service.ChangeTodolist(id, todo);
//        return JsonConvert.SerializeObject(new Status {status = "true"});
//      }
//      return JsonConvert.SerializeObject(new Status {status = "false"});
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
      _service.DeleteTodolist(id);
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = true
      });
    }
  }
}
