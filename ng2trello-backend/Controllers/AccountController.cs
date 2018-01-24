using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ng2trello_backend.Extensions;
using ng2trello_backend.Models;
using ng2trello_backend.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ng2trello_backend.Controllers
{
  [Route("api/[controller]")]
  public class AccountController : Controller
  {
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
      _service = service;
    }

    [HttpPost]
    public string Post([FromBody] JObject value)
    {
      var userData = value.BodyToDictionary();
      if (userData != null)
      {
        var action = userData["action"];
        var username = userData["username"];
        var password = userData["password"];
        switch (action)
        {
            case "register":
              return JsonConvert.SerializeObject(new StatusResponse
              {
                Status = _service.Register(username, password)
              });
            case "login":
              return JsonConvert.SerializeObject(new Token
              {
                token = _service.GetJwtToken(username, password)
              });
        }
      }
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = false
      });
    }

    private class Token
    {
      public string token { get; set; }
    }
  }
}
