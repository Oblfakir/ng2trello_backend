using System.Collections.Generic;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Interfaces
{
  public interface IBoardRepository
  {
    Board GetBoardById(int id);
    List<Board> GetAllBoards();
    int AddBoard(Board board);
    void DeleteBoard(int id);
    void ChangeBoard(int id, Board board);
  }
}
