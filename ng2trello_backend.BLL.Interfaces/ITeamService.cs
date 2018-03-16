using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Interfaces
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
