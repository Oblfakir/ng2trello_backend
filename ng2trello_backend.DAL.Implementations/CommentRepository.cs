using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.DAL.Implementations.Contexts;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Implementations
{
    public class CommentRepository : ICommentRepository
    {
        private readonly CommentContext _db;
        private readonly CardContext _dbCards;

        public CommentRepository(CommentContext db, CardContext cc)
        {
            _db = db;
            _dbCards = cc;
        }

        public Comment GetCommentById(int id)
        {
            return _db.Comments.Find(id);
        }

        public List<Comment> GetAllComments()
        {
            return _db.Comments.ToList();
        }

        public List<Comment> GetAllCommentsByCardId(int id)
        {
            return _db.Comments.Where(x => x.CardId == id).ToList();
        }

        public int AddComment(Comment comment)
        {
            if (comment == null) throw new Exception("AddComment method error: comment is null");
            _db.Comments.Add(comment);
            _db.SaveChanges();
            if (comment.CardId != null)
            {
                var card = _dbCards.Cards.Find(comment.CardId);
                card.AddCommentId(comment.Id);
                _dbCards.Update(card);
                _dbCards.SaveChanges();
            }
            return comment.Id;
        }

        public void DeleteComment(int id)
        {
            var comment = _db.Comments.Find(id);
            if (comment == null) throw new Exception($"DeleteComment method error: no comment with id {id} was found");
            _db.Comments.Remove(comment);
            _db.SaveChanges();
        }

        public void ChangeComment(int id, Comment newcomment)
        {
            var comment = _db.Comments.Find(id);
            if (comment == null) throw new Exception($"ChangeComment method error: no comment with id {id} was found");
            if (newcomment == null) throw new Exception("ChangeComment method error: comment is null");
           comment.CopyProps(newcomment);
            _db.Comments.Update(comment);
            _db.SaveChanges();
        }
    }
}
