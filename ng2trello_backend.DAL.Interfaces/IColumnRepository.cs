using System.Collections.Generic;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Interfaces
{
    public interface IColumnRepository
    {
        List<Column> GetAllColumns();
        List<Column> GetColumnByBoardId(int id);
        Column GetColumnById(int id);
        int AddColumn(Column column);
        void DeleteColumn(int id);
        void ChangeColumn(int id, Column content);
    }
}
