using System.Collections.Generic;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Interfaces
{
  public interface ICardRepository
  {
    List<Card> GetAllCards();
    List<Card> GetCardsByBoardId(int id);
    Card GetCardById(int id);
    int AddCard(Card card);
    void ChangeCard(int id, Card card);
    void DeleteCard(int id);
  }
}
