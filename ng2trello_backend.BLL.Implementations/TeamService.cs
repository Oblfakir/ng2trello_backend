using ng2trello_backend.BLL.Implementations.Extensions;
using ng2trello_backend.BLL.Interfaces;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities;
using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Implementations
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
