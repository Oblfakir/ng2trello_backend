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
    public class CardController : Controller
    {
        private readonly ICardService _service;
        private readonly ICardActionService _cardActionService;
        private readonly ICommentService _commentService;
        
        public CardController(ICardService service, ICardActionService cardActionService, ICommentService commentService)
        {
            _service = service;
            _cardActionService = cardActionService;
            _commentService = commentService;
        }

        [HttpGet]
        public string Get()
        {
            return _service.GetAllCards();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _service.GetCardById(id);
        }
        
        [HttpGet("{id}/cardactions")]
        public string GetActions(int id)
        {
            return _cardActionService.GetCardActionsByCardId(id);
        }
        
        [HttpGet("{id}/comments")]
        public string GetComments(int id)
        {
            return _commentService.GetAllCommentsByCardId(id);
        }

        [HttpPost]
        public string Post([FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerCard>>();
            if (dict != null)
            {
                return JsonConvert.SerializeObject(new StatusResponse
                {
                    Status = true,
                    NewItemId = _service.AddCard(dict["card"])
                });
            }
            return StatusResponse.FalseResponse();
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerCard>>();
            if (dict != null)
            {
                _service.ChangeCard(id, dict["card"]);
                return StatusResponse.TrueResponse();
            }
            return StatusResponse.FalseResponse();
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _service.DeleteCard(id);
            return StatusResponse.TrueResponse();
        }
    }
}
