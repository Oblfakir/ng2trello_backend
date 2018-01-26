using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Services.Interfaces
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
