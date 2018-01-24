using System.Security.Claims;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Interfaces
{
    public interface IUserRepository
    {
        bool Register(string login, string password);
        User GetUserByLogin(string login);
        ClaimsIdentity GetIdentity(string login, string password);
    }
}
