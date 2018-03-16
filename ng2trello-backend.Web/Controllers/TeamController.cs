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
        
        [HttpGet]
        public string Get()
        {
            return _service.GetAllTeams();
        }

        [HttpPost]
        public string Post([FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerTeam>>();
            if (dict != null)
            {
                return JsonConvert.SerializeObject(new StatusResponse
                {
                    Status = true,
                    NewItemId = _service.AddTeam(dict["team"])
                });
            }
            return StatusResponse.FalseResponse();
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerTeam>>();
            if (dict != null)
            {
                _service.ChangeTeam(id, dict["team"]);
                return StatusResponse.TrueResponse();
            }
            return StatusResponse.FalseResponse();
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _service.DeleteTeam(id);
            return StatusResponse.TrueResponse();
        }
    }
}
