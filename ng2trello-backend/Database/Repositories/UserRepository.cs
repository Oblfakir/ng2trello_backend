using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using ng2trello_backend.Database.Contexts;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Repositories
{
  public class UserRepository:IUserRepository
  {
    private readonly UserContext _db;

    public UserRepository(UserContext context)
    {
      _db = context;
    }

    public bool Register(string login, string password)
    {
      if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password)) throw new Exception("Register method error: login or password is empty");
      var alreadyExists = _db.Users.FirstOrDefault(u => u.Username == login) != null;
      if (alreadyExists) throw new Exception($"Register method error: user with login {login} already exists");
      byte[] salt = new byte[128 / 8];
      using (var rng = RandomNumberGenerator.Create())
      {
        rng.GetBytes(salt);
      }

      string passwordHash  = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password: password,
        salt: salt,
        prf: KeyDerivationPrf.HMACSHA1,
        iterationCount: 10000,
        numBytesRequested: 256 / 8));

      var user = new User
      {
        Id = GetNextUserId(),
        Username = login,
        Password = passwordHash,
        Salt = Convert.ToBase64String(salt),
        Role = "admin"
      };

      _db.Users.Add(user);
      _db.SaveChanges();
      return true;
    }

    public User GetUserByLogin(string login)
    {
      var user = _db.Users.FirstOrDefault(u => u.Username == login);
      if (user == null) throw new Exception($"GetUserByLogin method error: user with login {login} was not found");
      return user;
    }

    private User Login(string login, string password)
    {
      var user = _db.Users.FirstOrDefault(u => u.Username == login);
      if (user == null) throw new Exception($"Login method error: user with login {login} was not found");
      string passwordHash  = Convert.ToBase64String(KeyDerivation.Pbkdf2(
        password: password,
        salt: Convert.FromBase64String(user.Salt),
        prf: KeyDerivationPrf.HMACSHA1,
        iterationCount: 10000,
        numBytesRequested: 256 / 8));
      return passwordHash == user.Password ? user : null;
    }

    private int GetNextUserId()
    {
      return _db.Users.Any() ? _db.Users.Select(x => x.Id).Max() + 1 : 1;
    }

    public ClaimsIdentity GetIdentity(string login, string password)
    {
      var user = Login(login, password);
      if (user != null)
      {
        var claims = new List<Claim>
        {
          new Claim(ClaimsIdentity.DefaultNameClaimType, user.Username),
          new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role)
        };
        ClaimsIdentity claimsIdentity =
          new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
            ClaimsIdentity.DefaultRoleClaimType);
        return claimsIdentity;
      }
      else
      {
        throw new Exception("GetIdentity method error");
      }
    }
  }
}
