using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Models
{
  public class Board
  {
    public Board()
    {

    }
    public Board(SerBoard board)
    {
      Id = board.Id;
      Title = board.Title;
      ColumnIds = string.Join('#', board.ColumnIds);
      CardIds = string.Join('#', board.CardIds);
      ParticipantIds = string.Join('#', board.ParticipantIds);
      Status = board.Status;
      Sorting = board.Sorting;
    }
    public int Id { get; set; }
    public string Title { get; set; }
    public string ColumnIds { get; set; }
    public string CardIds { get; set; }
    public string ParticipantIds { get; set; }
    public string Status { get; set; }
    public string Sorting { get; set; }
  }
}
