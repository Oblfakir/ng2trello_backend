﻿using System.Collections.Generic;
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
    public class CardActionController : Controller
    {
        private readonly ICardActionService _service;

        public CardActionController(ICardActionService service)
        {
            _service = service;
        }

        [HttpGet]
        public string Get()
        {
            return _service.GetAllCardActions();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _service.GetCardActionById(id);
        }

        [HttpPost]
        public string Post([FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerCardAction>>();
            if (dict != null)
            {
                return JsonConvert.SerializeObject(new StatusResponse
                {
                    Status = true,
                    NewItemId = _service.AddCardAction(dict["cardAction"])
                });
            }
            return StatusResponse.FalseResponse();
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerCardAction>>();
            if (dict != null)
            {
                _service.ChangeCardAction(id, dict["cardAction"]);
                return StatusResponse.TrueResponse();
            }
            return StatusResponse.FalseResponse();
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _service.DeleteCardAction(id);
            return StatusResponse.TrueResponse();
        }
    }
}
