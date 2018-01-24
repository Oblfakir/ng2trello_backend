using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Database.Contexts;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Repositories
{
  public class CardRepository: ICardRepository
  {
    private readonly CardContext _db;

    public CardRepository(CardContext context)
    {
      _db = context;
    }

    public List<Card> GetAllCards()
    {
      return _db.Cards.ToList();
    }

    public List<Card> GetCardsByBoardId(int id)
    {
      return _db.Cards.Where(card => card.BoardId == id).ToList();
    }

    public Card GetCardById(int id)
    {
      var card = _db.Cards.Find(id);
      if (card == null) throw new Exception($"GetCardById method error: No card with id {id}");
      return card;
    }

    public int AddCard(Card card)
    {
      if ( card == null ) throw new Exception("AddCard method error: Card is null");
      card.Id = GetNextCardId();
      _db.Cards.Add(card);
      _db.SaveChanges();
      return card.Id;
    }

    public void ChangeCard(int id, Card card)
    {
      if ( card == null ) throw new Exception("ChangeCard method error: Card is null");
      var changingCard = _db.Cards.Find(id);
      if (changingCard == null) throw new Exception($"GetCardById method error: No card with id {id}");
      card.Id = id;
      _db.Cards.Update(card);
      _db.SaveChanges();
    }

    public void DeleteCard(int id)
    {
      var card = _db.Cards.Find(id);
      if (card == null) throw new Exception($"DeleteCard method error: No card with id {id}");
      _db.Cards.Remove(card);
      _db.SaveChanges();
    }

    private int GetNextCardId()
    {
      var ids = _db.Cards.ToList().Select(x => x.Id).ToList();
      return ids.Any() ? ids.Max() + 1 : 1;
    }
  }
}
