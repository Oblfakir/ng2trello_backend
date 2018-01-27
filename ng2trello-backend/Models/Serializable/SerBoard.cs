using System.Collections.Generic;
using System.Linq;

namespace ng2trello_backend.Models.Serializable
{
    public class SerBoard : SerializableBase
    {
        public SerBoard()
        {

        }

        public SerBoard(Board board)
        {
            Id = board.Id;
            Title = board.Title;
            ColumnIds = string.IsNullOrEmpty(board.ColumnIds) 
                ? new List<int>()
                : board.ColumnIds.Split('#').Select(int.Parse).ToList();
            CardIds = string.IsNullOrEmpty(board.ColumnIds) 
                ? new List<int>()
                : board.ColumnIds.Split('#').Select(int.Parse).ToList();
            ParticipantIds = string.IsNullOrEmpty(board.ColumnIds) 
                ? new List<int>()
                : board.ColumnIds.Split('#').Select(int.Parse).ToList();
            Status = board.Status;
            Sorting = board.Sorting;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public List<int> ColumnIds { get; set; }
        public List<int> CardIds { get; set; }
        public List<int> ParticipantIds { get; set; }
        public string Status { get; set; }
        public string Sorting { get; set; }
    }
}

