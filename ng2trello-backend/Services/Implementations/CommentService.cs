using System.Collections.Generic;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Extensions;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Interfaces;

namespace ng2trello_backend.Services.Implementations
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository _repository;

        public CommentService(ICommentRepository repository)
        {
            _repository = repository;
        }

        public string GetCommentById(int id)
        {
            return new SerComment(_repository.GetCommentById(id)).Serialize();
        }

        public string GetAllComments()
        {
            return _repository.GetAllComments().Serialize();
        }

        public int AddComment(SerComment comment)
        {
            return _repository.AddComment(new Comment(comment));
        }

        public void DeleteComment(int id)
        {
            _repository.DeleteComment(id);
        }

        public void ChangeComment(int id, SerComment comment)
        {
            _repository.ChangeComment(id, new Comment(comment));
        }
    }
}
