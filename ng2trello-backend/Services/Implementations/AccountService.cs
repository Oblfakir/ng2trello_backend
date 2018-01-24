using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Interfaces;

namespace ng2trello_backend.Services.Implementations
{
  public class AccountService: IAccountService
  {
    private readonly IUserRepository _repository;

    public AccountService(IUserRepository repository)
    {
      _repository = repository;
    }

    public string GetJwtToken(string login, string password)
    {
      try
      {
        var identity = _repository.GetIdentity(login, password);
        if (identity == null) throw new Exception("GetJwtToken method error: identity is null");
        var now = DateTime.UtcNow;
        var jwt = new JwtSecurityToken(
          issuer: AuthOptions.ISSUER,
          audience: AuthOptions.AUDIENCE,
          notBefore: now,
          claims: identity.Claims,
          expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
          signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
        return encodedJwt;
      }
      catch (Exception e)
      {
        Console.WriteLine(e);
        throw;
      }
    }

    public bool Register(string login, string password)
    {
      bool result;
      try
      {
        result = _repository.Register(login, password);
      }
      catch (Exception e)
      {
        return false;
      }
      return result;
    }

    public string GetUserData(string username)
    {
     return new SerUser( _repository.GetUserByLogin(username)).Serialize();
    }
  }
}
