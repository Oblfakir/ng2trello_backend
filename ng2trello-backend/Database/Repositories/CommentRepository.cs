using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Database.Contexts;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Repositories
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
            comment.Id = GetNextId();
            _db.Comments.Add(comment);
            if (comment.CardId != null)
            {
                var card = _dbCards.Cards.Find(comment.CardId);
                card.AddCommentId(comment.Id);
                _dbCards.Update(card);
                _dbCards.SaveChanges();
            }
            _db.SaveChanges();
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
            newcomment.Id = id;
            _db.Comments.Update(newcomment);
            _db.SaveChanges();
        }

        private int GetNextId()
        {
            return _db.Comments.Any() ? _db.Comments.Select(x => x.Id).Max() + 1 : 1;
        }
    }
}
