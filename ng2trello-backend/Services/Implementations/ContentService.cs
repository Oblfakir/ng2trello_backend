using System.Linq;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Extensions;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Interfaces;

namespace ng2trello_backend.Services.Implementations
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
