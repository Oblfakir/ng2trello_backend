using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [Authorize(AuthenticationSchemes = "Bearer", Policy = "registered")]
        [Route("data")]
        [HttpPost]
        public string ByJwt([FromBody] JObject value)
        {
            var userData = value?.BodyToDictionary();
            if (userData != null)
            {
                var handler = new JwtSecurityTokenHandler();

                try
                {
                    handler.ValidateToken(userData["token"], AuthOptions.GetValidationParameters(), out var validToken);

                    if (validToken is JwtSecurityToken validJwt)
                    {
                        var username = validJwt.Payload[ClaimsIdentity.DefaultNameClaimType];
                        return _service.GetUserData(username.ToString());
                    }
                }
                catch (Exception)
                {
                    return StatusResponse.FalseResponse();
                }
            }
            return StatusResponse.FalseResponse();
        }

        [Route("login")]
        [HttpPost]
        public string Login([FromBody] JObject value)
        {
            var userData = value.BodyToDictionary();
            if (userData != null)
            {
                var username = userData["username"];
                var password = userData["password"];
                return JsonConvert.SerializeObject(new StatusResponse
                {
                    Status = true,
                    Token = _service.GetJwtToken(username, password)
                });
            }

            return StatusResponse.FalseResponse();
        }

        [Route("register")]
        [HttpPost]
        public string Register([FromBody] JObject value)
        {
            var userData = value.BodyToDictionary();
            if (userData != null)
            {
                var username = userData["username"];
                var password = userData["password"];
                if (_service.Register(username, password))
                {
                    return JsonConvert.SerializeObject(new StatusResponse
                    {
                        Status = true,
                        Token = _service.GetJwtToken(username, password)
                    });
                }
            }

            return StatusResponse.FalseResponse();
        }
    }
}
