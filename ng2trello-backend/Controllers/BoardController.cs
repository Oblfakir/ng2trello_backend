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
    public class BoardController : Controller
    {
        private readonly IBoardService _service;
        private readonly ICardService _cardService;
        private readonly IColumnService _columnService;

        public BoardController(IBoardService service, ICardService cardService, IColumnService columnService)
        {
            _service = service;
            _cardService = cardService;
            _columnService = columnService;
        }

        [HttpGet]
        public string Get()
        {
            return _service.GetAllBoards();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return _service.GetBoardById(id);
        }
        
        [HttpGet("{id}/cards")]
        public string GetCards(int id)
        {
            return _cardService.GetCardsByBoardId(id);
        }
        
        [HttpGet("{id}/columns")]
        public string GetColumns(int id)
        {
            return _columnService.GetColumnsByBoardId(id);
        }

        [HttpPost]
        public string Post([FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerBoard>>();
            if (dict != null)
            {
                return JsonConvert.SerializeObject(new StatusResponse
                {
                    Status = true,
                    NewItemId = _service.AddBoard(dict["board"])
                });
            }
            return StatusResponse.FalseResponse();
        }

        [HttpPut("{id}")]
        public string Put(int id, [FromBody] JObject value)
        {
            var dict = value.ToObject<Dictionary<string, SerBoard>>();
            if (dict != null)
            {
                _service.ChangeBoard(id, dict["board"]);
                return StatusResponse.TrueResponse();
            }
            return StatusResponse.FalseResponse();
        }

        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            _service.DeleteBoard(id);
            return StatusResponse.TrueResponse();
        }
    }
}
