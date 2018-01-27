using System;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Extensions;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Interfaces;

namespace ng2trello_backend.Services.Implementations
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _repository;

        public BoardService(IBoardRepository repository)
        {
            _repository = repository;
        }

        public string GetBoardById(int id)
        {
            Board board = null;
            try
            {
                board = _repository.GetBoardById(id);
            }
            catch
            {
                
            }
            return new SerBoard(board).Serialize();
        }

        public string GetAllBoards()
        {
            return _repository.GetAllBoards().Serialize();
        }

        public int AddBoard(SerBoard board)
        {
            return _repository.AddBoard(new Board(board));
        }

        public void DeleteBoard(int id)
        {
            _repository.DeleteBoard(id);
        }

        public void ChangeBoard(int id, SerBoard board)
        {
            _repository.ChangeBoard(id, new Board(board));
        }
    }
}
