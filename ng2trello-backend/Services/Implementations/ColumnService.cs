using System.Linq;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Extensions;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Interfaces;

namespace ng2trello_backend.Services.Implementations
{
    public class ColumnService : IColumnService
    {
        private readonly IColumnRepository _repository;

        public ColumnService(IColumnRepository repository)
        {
            _repository = repository;
        }

        public string GetAllColumns()
        {
            return _repository.GetAllColumns().Select(x => new SerColumn(x)).Serialize();
        }

        public string GetColumnsByBoardId(int id)
        {
            return _repository.GetColumnByBoardId(id).Select(x => new SerColumn(x)).Serialize();
        }

        public string GetColumnById(int id)
        {
            return new SerColumn(_repository.GetColumnById(id)).Serialize();
        }

        public int AddColumn(SerColumn content)
        {
            return _repository.AddColumn(new Column(content));
        }

        public void DeleteColumn(int id)
        {
            _repository.DeleteColumn(id);
        }

        public void ChangeColumn(int id, SerColumn content)
        {
            _repository.ChangeColumn(id, new Column(content));
        }
    }
}
