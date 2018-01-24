using System.Collections.Generic;
using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Services.Interfaces
{
  public interface IContentService
  {
    string GetAllContent();
    string GetContentByCardId(int id);
    int AddContent(SerContent content);
    void DeleteContent(int id);
    void ChangeContent(int id, SerContent content);
  }
}
