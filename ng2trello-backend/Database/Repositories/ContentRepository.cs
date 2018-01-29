using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Database.Contexts;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Repositories
{
    public class ContentRepository : IContentRepository
    {
        private readonly ContentContext _db;

        public ContentRepository(ContentContext db)
        {
            _db = db;
        }

        public List<Content> GetAllContent()
        {
            return _db.Contents.ToList();
        }

        public List<Content> GetContentByCardId(int id)
        {
            return _db.Contents.Where(x => x.CardId == id).ToList();
        }

        public int AddContent(Content content)
        {
            if (content == null) throw new Exception("AddContent method error: content is null");
            _db.Contents.Add(content);
            _db.SaveChanges();
            return content.Id;
        }

        public void DeleteContent(int id)
        {
            var content = _db.Contents.Find(id);
            if (content == null) throw new Exception($"DeleteContent method error: Content with id {id} was not found");
            _db.Contents.Remove(content);
            _db.SaveChanges();
        }

        public void ChangeContent(int id, Content newcontent)
        {
            var content = _db.Contents.Find(id);
            if (content == null) throw new Exception($"ChangeContent method error: Content with id {id} was not found");
            if (newcontent == null) throw new Exception("ChangeContent method error: Content is null");
            content.CopyProps(newcontent);
            _db.Contents.Update(content);
            _db.SaveChanges();
        }
    }
}
