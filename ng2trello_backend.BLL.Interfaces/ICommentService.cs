using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Interfaces
{
    public interface ICommentService
    {
        string GetCommentById(int id);
        string GetAllComments();
        string GetAllCommentsByCardId(int id);
        int AddComment(SerComment comment);
        void DeleteComment(int id);
        void ChangeComment(int id, SerComment comment);
    }
}
