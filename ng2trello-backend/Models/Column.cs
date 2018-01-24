using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Models
{
  public class Column
  {
    public Column()
    {

    }

    public Column(SerColumn column)
    {
      Id = column.Id;
      BoardId = column.BoardId;
      CardIds = string.Join('#', column.CardIds);
      Title = column.Title;
    }

    public int Id { get; set; }
    public int BoardId { get; set; }
    public string CardIds { get; set; }
    public string Title { get; set; }
  }
}
