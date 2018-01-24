using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Database.Contexts;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Repositories
{
    public class CardActionRepository : ICardActionRepository
    {
        private readonly CardActionContext _db;

        public CardActionRepository(CardActionContext db)
        {
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
            cardAction.Id = GetNextId();
            _db.CardActions.Add(cardAction);
            _db.SaveChanges();
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
            newCardAction.Id = id;
            _db.CardActions.Add(newCardAction);
            _db.SaveChanges();
        }

        private int GetNextId()
        {
            return _db.CardActions.Any() ? _db.CardActions.Select(x => x.Id).Max() + 1 : 1;
        }
    }
}
