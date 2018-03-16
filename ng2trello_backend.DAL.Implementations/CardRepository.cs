using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.DAL.Implementations.Contexts;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Implementations
{
    public class CardRepository : ICardRepository
    {
        private readonly CardContext _db;
        private readonly BoardContext _dbBoard;
        private readonly ColumnContext _dbColumn;
        private readonly TodolistContext _todolistContext;
        private readonly CardActionContext _cardActionContext;

        public CardRepository(CardContext context, 
            CardActionContext cardActionContext,
            BoardContext boardContext, ColumnContext columnContext, 
            TodolistContext todolistContext)
        {
            _db = context;
            _dbBoard = boardContext;
            _dbColumn = columnContext;
            _todolistContext = todolistContext;
            _cardActionContext = cardActionContext;
        }

        public List<Card> GetAllCards()
        {
            return _db.Cards.ToList();
        }

        public List<Card> GetCardsByBoardId(int id)
        {
            return _db.Cards.Where(card => card.BoardId == id).ToList();
        }

        public List<Card> GetCardsByColumnId(int id)
        {
            return _db.Cards.Where(card => card.ColumnId == id).ToList();
        }

        public Card GetCardById(int id)
        {
            var card = _db.Cards.Find(id);
            if (card == null) throw new Exception($"GetCardById method error: No card with id {id}");
            return card;
        }

        public int AddCard(Card card)
        {
            if (card == null) throw new Exception("AddCard method error: Card is null");


            var todolist = new Todolist
            {
                Title = "Todolist",
                TodoIds = ""
            };
            
            _todolistContext.Todolists.Add(todolist);
            _todolistContext.SaveChanges();

            card.TodolistId = todolist.Id;
            _db.Cards.Add(card);
            _db.SaveChanges();
            
            var board = _dbBoard.Boards.Find(card.BoardId);
            board.AddCardId(card.Id);
            _dbBoard.Boards.Update(board);
            _dbBoard.SaveChanges();
            
            var column = _dbColumn.Columns.Find(card.ColumnId);
            column.AddCardId(card.Id);
            _dbColumn.Columns.Update(column);
            _dbColumn.SaveChanges();
            
            return card.Id;
        }

        public void ChangeCard(int id, Card card)
        {
            if (card == null) throw new Exception("ChangeCard method error: Card is null");
            var changingCard = _db.Cards.Find(id);
            if (changingCard == null) throw new Exception($"GetCardById method error: No card with id {id}");
            changingCard.CopyParams(card);
            _db.Cards.Update(changingCard);
            _db.SaveChanges();
        }

        public void DeleteCard(int id)
        {
            var card = _db.Cards.Find(id);
            if (card == null) throw new Exception($"DeleteCard method error: No card with id {id}");
            var board = _dbBoard.Boards.Find(card.BoardId);
            board.DeleteCardId(card.Id);
            _dbBoard.Boards.Update(board);
            _dbBoard.SaveChanges();
            
            var column = _dbColumn.Columns.Find(card.ColumnId);
            column.DeleteCardId(card.Id);
            _dbColumn.Columns.Update(column);
            _dbColumn.SaveChanges();

            foreach (var actionId in card.GetActionIds())
            {
                var cardAction = _cardActionContext.CardActions.Find(actionId);
                if (cardAction != null)
                {
                    _cardActionContext.CardActions.Remove(cardAction);
                }
            }
            _cardActionContext.SaveChanges();
            _db.Cards.Remove(card);
            _db.SaveChanges();
        }
    }
}
