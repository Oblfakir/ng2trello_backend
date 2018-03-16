using System.Collections.Generic;
using System.Linq;

namespace ng2trello_backend.Entities.Serializable
{
    public class SerCard : SerializableBase
    {
        public SerCard()
        {

        }

        public SerCard(Card card)
        {
            Title = card.Title;
            Id = card.Id;
            ParticipantIds = card.GetParticipantIds();
            BoardId = card.BoardId;
            CreationTimestamp = card.CreationTimestamp;
            ExpirationTimestamp = card.ExpirationTimestamp;
            ColumnId = card.ColumnId;
            ActionIds = string.IsNullOrEmpty(card.ActionIds) ? new List<int>() :card.ActionIds.Split('#').Select(int.Parse).ToList();
            Labels = string.IsNullOrEmpty(card.Labels) ? new List<string>() : card.Labels.Split('#').ToList();
            TodolistId = card.TodolistId;
            CommentIds = string.IsNullOrEmpty(card.CommentIds) ? new List<int>() : card.CommentIds.Split('#').Select(int.Parse).ToList();
        }

        public string Title { get; set; }
        public int Id { get; set; }
        public List<int> ParticipantIds { get; set; }
        public int BoardId { get; set; }
        public long CreationTimestamp { get; set; }
        public long ExpirationTimestamp { get; set; }
        public int ColumnId { get; set; }
        public List<int> ActionIds { get; set; }
        public List<string> Labels { get; set; }
        public int? TodolistId { get; set; }
        public List<int> CommentIds { get; set; }
    }
}
