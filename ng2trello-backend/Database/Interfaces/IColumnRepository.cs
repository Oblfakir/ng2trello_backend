using System.Collections.Generic;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Interfaces
{
    public interface IColumnRepository
    {
        List<Column> GetAllColumns();
        List<Column> GetColumnByBoardId(int id);
        Column GetColumnById(int id);
        int AddColumn(Column content);
        void DeleteColumn(int id);
        void ChangeColumn(int id, Column content);
    }
}
