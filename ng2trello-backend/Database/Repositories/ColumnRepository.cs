using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Database.Contexts;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Repositories
{
    public class ColumnRepository : IColumnRepository
    {
        private readonly ColumnContext _db;

        public ColumnRepository(ColumnContext db)
        {
            _db = db;
        }

        public List<Column> GetAllColumns()
        {
            return _db.Columns.ToList();
        }

        public List<Column> GetColumnByBoardId(int id)
        {
            return _db.Columns.Where(x => x.BoardId == id).ToList();
        }

        public Column GetColumnById(int id)
        {
            return _db.Columns.Find(id);
        }

        public int AddColumn(Column content)
        {
            if (content == null) throw new Exception("AddColumn method error: column is null");
            content.Id = GetNextId();
            _db.Columns.Add(content);
            _db.SaveChanges();
            return content.Id;
        }

        public void DeleteColumn(int id)
        {
            var column = _db.Columns.Find(id);
            if (column == null) throw new Exception($"DeleteColumn method error: column with id {id} was not found");
            _db.Columns.Remove(column);
            _db.SaveChanges();
        }

        public void ChangeColumn(int id, Column content)
        {
            var column = _db.Columns.Find(id);
            if (column == null) throw new Exception($"ChangeColumn method error: column with id {id} was not found");
            if (content == null) throw new Exception("ChangeColumn method error: column is null");
            _db.Columns.Update(content);
            _db.SaveChanges();
        }

        private int GetNextId()
        {
            return _db.Columns.Any() ? _db.Columns.Select(x => x.Id).Max() + 1 : 1;
        }
    }
}
