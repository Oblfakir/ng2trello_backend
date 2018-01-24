using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Services.Interfaces
{
    public interface ICardService
    {
        string GetAllCards();
        string GetCardsByBoardId(int id);
        string GetCardById(int id);
        int AddCard(SerCard card);
        void ChangeCard(int id, SerCard card);
        void DeleteCard(int id);
    }
}
