using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Database.Contexts;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Repositories
{
    public class BoardRepository : IBoardRepository
    {
        private readonly BoardContext _db;
        public BoardRepository(BoardContext context)
        {
            _db = context;
        }

        public Board GetBoardById(int id)
        {
            return _db.Boards.Find(id);
        }

        public List<Board> GetAllBoards()
        {
            return _db.Boards.ToList();
        }

        public int AddBoard(Board board)
        {
            if (board == null) throw new Exception("AddBoard method error: board is null");
            board.Id = GetNextId();
            _db.Boards.Add(board);
            _db.SaveChanges();
            return board.Id;
        }

        public void DeleteBoard(int id)
        {
            var board = _db.Boards.Find(id);
            if (board == null) throw new Exception($"DeleteBoard method error: no board with id {id}");
            _db.Boards.Remove(board);
            _db.SaveChanges();
        }

        public void ChangeBoard(int id, Board newboard)
        {
            var board = _db.Boards.Find(id);
            if (board == null) throw new Exception($"ChangeBoard method error: no board with id {id}");
            newboard.Id = id;
            _db.Boards.Update(newboard);
            _db.SaveChanges();
        }

        private int GetNextId()
        {
            return _db.Boards.Any() ? _db.Boards.Select(x => x.Id).Max() + 1 : 1;
        }
    }
}
