using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ng2trello_backend.BLL.Interfaces;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Implementations
{
    public class AccountService : IAccountService
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
                var jwt = new JwtSecurityToken(AuthOptions.ISSUER, AuthOptions.AUDIENCE,
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
            catch
            {
                return false;
            }
            return result;
        }

        public string GetUserData(string username)
        {
            return new SerUser(_repository.GetUserByLogin(username)).Serialize();
        }
    }
}
