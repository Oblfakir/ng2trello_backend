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
      var requestDict = value.ToObject<Dictionary<string, object>>();
      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, SerContent>>();
      if (dict != null)
      {
        return JsonConvert.SerializeObject(new StatusResponse
        {
          Status = true,
          NewItemId = _service.AddContent(dict["content"])
        });
      }
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = false
      });
    }

    [HttpPut("{id}")]
    public string Post(int id, [FromBody] JObject value)
    {
      var requestDict = value.ToObject<Dictionary<string, object>>();
      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, SerContent>>();
      if (dict != null)
      {
        _service.ChangeContent(id, dict["content"]);
        return JsonConvert.SerializeObject(new StatusResponse
        {
          Status = true
        });
      }
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = false
      });
    }

    [HttpDelete("{id}")]
    public string Delete(int id)
    {
      _service.DeleteContent(id);
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = true
      });
    }
  }
}
