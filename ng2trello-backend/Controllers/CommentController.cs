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
      var requestDict = value.ToObject<Dictionary<string, object>>();
      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, SerComment>>();
      if (dict != null)
      {
        var newItemId = _service.AddComment(dict["comment"]);
        return JsonConvert.SerializeObject(new StatusResponse
        {
          Status = true,
          NewItemId = newItemId
        });
      }
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = false
      });
//      var requestDict = value.ToObject<Dictionary<string, object>>();
//      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, JObject>>();
//      var commentdict = dict?["comment"].ToObject<Dictionary<string, string>>();
//      if (commentdict != null)
//      {
//        var comment = new SerComment
//        {
//          Id = int.Parse(commentdict["Id"]),
//          UserId = int.Parse(commentdict["UserId"]),
//          Text = commentdict["Text"],
//          Data = commentdict["Data"]
//        };
//        _service.AddComment(comment);
//        return JsonConvert.SerializeObject(new Status {status = "true"});
//      }
//      return JsonConvert.SerializeObject(new Status {status = "false"});
    }

    [HttpPut("{id}")]
    public string Put(int id, [FromBody] JObject value)
    {
      var requestDict = value.ToObject<Dictionary<string, object>>();
      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, SerComment>>();
      if (dict != null)
      {
        _service.ChangeComment(id, dict["comment"]);
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
//      var commentdict = dict?["comment"].ToObject<Dictionary<string, string>>();
//      if (commentdict != null)
//      {
//        var comment = new SerComment
//        {
//          Id = int.Parse(commentdict["Id"]),
//          UserId = int.Parse(commentdict["UserId"]),
//          Text = commentdict["Text"],
//          Data = commentdict["Data"]
//        };
//        _service.ChangeComment(id, comment);
//        return JsonConvert.SerializeObject(new Status {status = "true"});
//      }
//      return JsonConvert.SerializeObject(new Status {status = "false"});
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
      _service.DeleteComment(id);
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = true
      });
    }
  }
}
