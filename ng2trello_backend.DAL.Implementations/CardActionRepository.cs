using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.DAL.Implementations.Contexts;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Implementations
{
    public class CardActionRepository : ICardActionRepository
    {
        private readonly CardActionContext _db;
        private readonly CardContext _dbCards;

        public CardActionRepository(CardActionContext db, CardContext cc)
        {
            _dbCards = cc;
            _db = db;
        }

        public List<CardAction> GetCardActionsByCardId(int id)
        {
            return _db.CardActions.Where(x => x.CardId == id).ToList();
        }

        public List<CardAction> GetAllCardActions()
        {
            return _db.CardActions.ToList();
        }

        public CardAction GetCardActionById(int id)
        {
            return _db.CardActions.Find(id);
        }

        public int AddCardAction(CardAction cardAction)
        {
            if (cardAction == null) throw new Exception("AddCardAction method error: cardAction is null");
            _db.CardActions.Add(cardAction);
            _db.SaveChanges();
            
            var card = _dbCards.Cards.Find(cardAction.CardId);
            card.AddActionId(cardAction.Id);
            _dbCards.Cards.Update(card);
            _dbCards.SaveChanges();
            return cardAction.Id;
        }

        public void DeleteCardAction(int id)
        {
            var cardAction = _db.CardActions.Find(id);
            if (cardAction == null) throw new Exception($"DeleteCardAction method error: cardAction with id {id} was not found");
            _db.CardActions.Remove(cardAction);
            _db.SaveChanges();
        }

        public void ChangeCardAction(int id, CardAction newCardAction)
        {
            var cardAction = _db.CardActions.Find(id);
            if (cardAction == null) throw new Exception($"ChangeCardAction method error: cardAction with id {id} was not found");
            if (newCardAction == null) throw new Exception("ChangeCardAction method error: cardAction is null");
            cardAction.CopyProps(newCardAction);
            _db.CardActions.Update(cardAction);
            _db.SaveChanges();
        }
    }
}
