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
        private readonly BoardContext _dbBoards;

        public ColumnRepository(ColumnContext db, BoardContext boardContext)
        {
            _db = db;
            _dbBoards = boardContext;
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

        public int AddColumn(Column column)
        {
            if (column == null) throw new Exception("AddColumn method error: column is null");
            var board = _dbBoards.Boards.Find(column.BoardId);
            if ( board == null) throw new Exception("AddColumn method error: board is null");
            _db.Columns.Add(column);
            _db.SaveChanges();
            board.AddColumnId(column.Id);
            _dbBoards.Update(board);
            _dbBoards.SaveChanges();
            return column.Id;
        }

        public void DeleteColumn(int id)
        {
            var column = _db.Columns.Find(id);
            if (column == null) throw new Exception($"DeleteColumn method error: column with id {id} was not found");
            var board = _dbBoards.Boards.Find(column.BoardId);
            if ( board == null) throw new Exception("DeleteColumn method error: board is null");
            board.DeleteColumnId(column.Id);
            _db.Columns.Remove(column);
            _dbBoards.Update(board);
            _dbBoards.SaveChanges();
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
    }
}
