using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Models
{
    public class Team
    {
        public Team()
        {

        }

        public Team(SerTeam team)
        {
            Id = team.Id;
            ParticipantIds = string.Join('#', team.ParticipantIds);
            Title = team.Title;
            BoardIds = string.Join('#', team.BoardIds);
        }

        public int Id { get; set; }
        public string ParticipantIds { get; set; }
        public string Title { get; set; }
        public string BoardIds { get; set; }
    }
}

