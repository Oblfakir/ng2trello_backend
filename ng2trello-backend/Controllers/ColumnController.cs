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
    public class ColumnController : Controller
    {
        private readonly IColumnService _service;
        public ColumnController(IColumnService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Get()
        {
            return _service.GetAllColumns();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _service.GetColumnById(id);
        }

        [HttpPost("{boardid}")]
        public string Post(int boardid)
        {
            return _service.GetColumnsByBoardId(boardid);
        }

        [HttpPost]
        public string Post([FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerColumn>>();
            if (dict != null)
            {
                return JsonConvert.SerializeObject(new StatusResponse
                {
                    Status = true,
                    NewItemId = _service.AddColumn(dict["column"])
                });
            }
            return StatusResponse.FalseResponse();
        }

        [HttpPut("{id}")]
        public string Post(int id, [FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerColumn>>();
            if (dict != null)
            {
                _service.ChangeColumn(id, dict["column"]);
                return StatusResponse.TrueResponse();
            }
            return StatusResponse.FalseResponse();
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _service.DeleteColumn(id);
            return StatusResponse.TrueResponse();
        }
    }
}
