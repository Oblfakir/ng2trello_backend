using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Interfaces
{
    public interface IBoardService
    {
        string GetBoardById(int id);
        string GetAllBoards();
        int AddBoard(SerBoard board);
        void DeleteBoard(int id);
        void ChangeBoard(int id, SerBoard board);
    }
}
