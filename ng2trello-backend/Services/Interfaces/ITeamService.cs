using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Services.Interfaces
{
    public interface ITeamService
    {
        string GetTeamById(int id);
        string GetAllTeams();
        int AddTeam(SerTeam team);
        void DeleteTeam(int id);
        void ChangeTeam(int id, SerTeam team);
    }
}
