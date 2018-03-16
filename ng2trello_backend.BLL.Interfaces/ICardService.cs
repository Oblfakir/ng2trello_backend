using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Interfaces
{
    public interface ICardService
    {
        string GetAllCards();
        string GetCardsByBoardId(int id);
        string GetCardsByColumnId(int id);
        string GetCardById(int id);
        int AddCard(SerCard card);
        void ChangeCard(int id, SerCard card);
        void DeleteCard(int id);
    }
}
