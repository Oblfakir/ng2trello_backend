using System.Linq;
using ng2trello_backend.BLL.Implementations.Extensions;
using ng2trello_backend.BLL.Interfaces;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities;
using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Implementations
{
    public class ContentService : IContentService
    {
        private readonly IContentRepository _repository;

        public ContentService(IContentRepository repository)
        {
            _repository = repository;
        }

        public string GetAllContent()
        {
            return _repository.GetAllContent().Select(x => new SerContent(x)).Serialize();
        }

        public string GetContentByCardId(int id)
        {
            return _repository.GetContentByCardId(id).Select(x => new SerContent(x)).Serialize();
        }

        public int AddContent(SerContent content)
        {
            return _repository.AddContent(new Content(content));
        }

        public void DeleteContent(int id)
        {
            _repository.DeleteContent(id);
        }

        public void ChangeContent(int id, SerContent content)
        {
            _repository.ChangeContent(id, new Content(content));
        }
    }
}
