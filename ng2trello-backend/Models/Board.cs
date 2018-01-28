using System.Collections.Generic;
using System.Linq;
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
    
    public List<int> GetColumnIds()
    {
      return string.IsNullOrEmpty(ColumnIds)
        ? new List<int>()
        : ColumnIds.Split('#').Select(int.Parse).ToList();
    }
    
    public List<int> GetCardIds()
    {
      return string.IsNullOrEmpty(CardIds)
        ? new List<int>()
        : CardIds.Split('#').Select(int.Parse).ToList();
    }

    public void AddColumnId(int id)
    {
      if (GetColumnIds().Count < 1)
      {
        ColumnIds = id.ToString();
      }
      else
      {
        ColumnIds = ColumnIds + '#' + id;
      }
    }

    public void DeleteColumnId(int id)
    {
      var columnIds = GetColumnIds();
      if (columnIds.Contains(id))
      {
        ColumnIds = string.Join('#', columnIds.Where(x => x != id));
      }
    }
    
    public void AddCardId(int id)
    {
      if (GetCardIds().Count < 1)
      {
        CardIds = id.ToString();
      }
      else
      {
        CardIds = CardIds + '#' + id;
      }
    }

    public void DeleteCardId(int id)
    {
      var cardIds = GetCardIds();
      if (cardIds.Contains(id))
      {
        CardIds = string.Join('#', cardIds.Where(x => x != id));
      }
    }
  }
}
