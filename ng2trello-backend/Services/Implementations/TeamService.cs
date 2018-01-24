using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Extensions;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Interfaces;

namespace ng2trello_backend.Services.Implementations
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _repository;

        public TeamService(ITeamRepository repository)
        {
            _repository = repository;
        }

        public string GetTeamById(int id)
        {
            return new SerTeam(_repository.GetTeamById(id)).Serialize();
        }

        public string GetAllTeams()
        {
            return _repository.GetAllTeams().Serialize();
        }

        public int AddTeam(SerTeam team)
        {
            return _repository.AddTeam(new Team(team));
        }

        public void DeleteTeam(int id)
        {
            _repository.DeleteTeam(id);
        }

        public void ChangeTeam(int id, SerTeam team)
        {
            _repository.ChangeTeam(id, new Team(team));
        }
    }
}
