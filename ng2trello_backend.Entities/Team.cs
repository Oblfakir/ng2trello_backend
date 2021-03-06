﻿using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.Entities
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

        public void CopyProps(Team team)
        {
            ParticipantIds = team.ParticipantIds;
            Title = team.Title;
            BoardIds = team.BoardIds;
        }

        public int Id { get; set; }
        public string ParticipantIds { get; set; }
        public string Title { get; set; }
        public string BoardIds { get; set; }
    }
}

