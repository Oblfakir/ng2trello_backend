using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Services.Interfaces
{
  public interface IColumnService
  {
    string GetAllColumns();
    string GetColumnsByBoardId(int id);
    string GetColumnById(int id);
    int AddColumn(SerColumn content);
    void DeleteColumn(int id);
    void ChangeColumn(int id, SerColumn content);
  }
}
