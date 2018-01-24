using System.Collections.Generic;
using System.Linq;

namespace ng2trello_backend.Models.Serializable
{
    public class SerTeam : SerializableBase
    {
        public SerTeam()
        {

        }

        public SerTeam(Team team)
        {
            Id = team.Id;
            Title = team.Title;
            ParticipantIds = team.ParticipantIds.Split('#').Select(int.Parse).ToList();
            BoardIds = team.BoardIds.Split('#').Select(int.Parse).ToList();
        }

        public int Id { get; set; }
        public List<int> ParticipantIds { get; set; }
        public string Title { get; set; }
        public List<int> BoardIds { get; set; }
    }
}
