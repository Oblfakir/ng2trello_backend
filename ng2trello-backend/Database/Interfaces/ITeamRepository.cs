using System.Collections.Generic;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Interfaces
{
    public interface ITeamRepository
    {
        Team GetTeamById(int id);
        List<Team> GetAllTeams();
        int AddTeam(Team team);
        void DeleteTeam(int id);
        void ChangeTeam(int id, Team team);
    }
}
