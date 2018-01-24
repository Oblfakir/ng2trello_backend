using System.Collections.Generic;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Interfaces
{
    public interface ICommentRepository
    {
        Comment GetCommentById(int id);
        List<Comment> GetAllComments();
        int AddComment(Comment comment);
        void DeleteComment(int id);
        void ChangeComment(int id, Comment comment);
    }
}
