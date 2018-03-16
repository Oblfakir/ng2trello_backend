using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Interfaces
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
