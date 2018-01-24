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
  public class TeamController : Controller
  {
    private readonly ITeamService _service;
    public TeamController(ITeamService service)
    {
      _service = service;
    }

    [HttpGet("{id}")]
    public string Get(int id)
    {
      return _service.GetTeamById(id);
    }

    [HttpPost]
    public string Post([FromBody] JObject value)
    {
      var requestDict = value.ToObject<Dictionary<string, object>>();
      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, SerTeam>>();
      if (dict != null)
      {
        return JsonConvert.SerializeObject(new StatusResponse
        {
          Status = true,
          NewItemId = _service.AddTeam(dict["team"])
        });
      }
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = false
      });
    }

    [HttpPut("{id}")]
    public string Put(int id, [FromBody] JObject value)
    {
      var requestDict = value.ToObject<Dictionary<string, object>>();
      var dict = (requestDict?["body"] as JObject)?.ToObject<Dictionary<string, SerTeam>>();
      if (dict != null)
      {
        _service.ChangeTeam(id, dict["team"]);
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
      _service.DeleteTeam(id);
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = true
      });
    }
  }
}
