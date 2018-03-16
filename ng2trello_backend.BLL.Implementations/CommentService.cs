using ng2trello_backend.BLL.Implementations.Extensions;
using ng2trello_backend.BLL.Interfaces;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities;
using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Implementations
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

        public string GetAllCommentsByCardId(int id)
        {
            return _repository.GetAllCommentsByCardId(id).Serialize();
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
