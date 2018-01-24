using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ng2trello_backend.Extensions;
using ng2trello_backend.Models;
using ng2trello_backend.Services.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ng2trello_backend.Controllers
{
  [Route("api/[controller]")]
  public class UserController : Controller
  {
    private readonly IAccountService _service;

    public UserController(IAccountService service)
    {
      _service = service;
    }
    
    [Route("byjwt")]
    [HttpPost]
    public string ByJwt([FromBody] JObject value)
    {
      var userData = value.BodyToDictionary();
      if (userData != null)
      {
        var handler = new JwtSecurityTokenHandler();

        try
        {
          handler.ValidateToken(userData["jwt"], AuthOptions.GetValidationParameters(), out var validToken);

          if (validToken is JwtSecurityToken validJwt)
          {
            var username = validJwt.Payload[ClaimsIdentity.DefaultNameClaimType];
            return _service.GetUserData(username.ToString());
          }
        }
        catch (Exception)
        {
          return JsonConvert.SerializeObject(new StatusResponse
          {
            Status = false
          });
        }
      }
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = false
      });
    }

    [Route("data")]
    [HttpPost]
    public string Post([FromBody] JObject value)
    {
      var userData = value.BodyToDictionary();
      if (userData != null)
      {
        return _service.GetUserData(userData["username"]);
      }
      return JsonConvert.SerializeObject(new StatusResponse
      {
        Status = false
      });
    }
  }
}
