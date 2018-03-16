using System.Collections.Generic;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Interfaces
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int id);
        List<Comment> GetAllComments();
        List<Comment> GetAllCommentsByCardId(int id);
        int AddComment(Comment comment);
        void DeleteComment(int id);
        void ChangeComment(int id, Comment comment);
    }
}
