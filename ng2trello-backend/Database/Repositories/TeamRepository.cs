using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Database.Contexts;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Repositories
{
  public class TeamRepository: ITeamRepository
  {
    private readonly TeamContext _db;

    public TeamRepository(TeamContext db)
    {
      _db = db;
    }

    public Team GetTeamById(int id)
    {
      return _db.Teams.Find(id);
    }

    public List<Team> GetAllTeams()
    {
      return _db.Teams.ToList();
    }

    public int AddTeam(Team team)
    {
      if (team == null) throw new Exception("AddTeam method error: team is null");
      team.Id = GetNextId();
      _db.Teams.Add(team);
      _db.SaveChanges();
      return team.Id;
    }

    public void DeleteTeam(int id)
    {
      var team = _db.Teams.Find(id);
      if (team == null) throw new Exception($"DeleteTeam method error: no team with id {id}");
      _db.Teams.Remove(team);
      _db.SaveChanges();
    }

    public void ChangeTeam(int id, Team newteam)
    {
      var team = _db.Teams.Find(id);
      if (newteam == null) throw new Exception("ChangeTeam method error: team is null");
      if (team == null) throw new Exception($"ChangeTeam method error: no team with id {id}");
      newteam.Id = id;
      _db.Teams.Update(newteam);
      _db.SaveChanges();
    }

    private int GetNextId()
    {
      return _db.Teams.Any() ? _db.Teams.Select(x => x.Id).Max()+1 : 1;
    }
  }
}
