namespace ng2trello_backend.BLL.Interfaces
{
    public interface IAccountService
    {
        string GetJwtToken(string login, string password);
        bool Register(string login, string password);
        string GetUserData(string username);
    }
}
