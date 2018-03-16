using System.Collections.Generic;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Interfaces
{
    public interface ICardRepository
    {
        List<Card> GetAllCards();
        List<Card> GetCardsByBoardId(int id);
        List<Card> GetCardsByColumnId(int id);
        Card GetCardById(int id);
        int AddCard(Card card);
        void ChangeCard(int id, Card card);
        void DeleteCard(int id);
    }
}
