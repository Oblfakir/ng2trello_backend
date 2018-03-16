using System.Collections.Generic;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Interfaces
{
    public interface IContentRepository
    {
        List<Content> GetAllContent();
        List<Content> GetContentByCardId(int id);
        int AddContent(Content content);
        void DeleteContent(int id);
        void ChangeContent(int id, Content content);
    }
}
