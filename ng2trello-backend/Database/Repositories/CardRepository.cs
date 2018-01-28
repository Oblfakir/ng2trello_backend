using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Database.Contexts;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Repositories
{
    public class CardRepository : ICardRepository
    {
        private readonly CardContext _db;
        private readonly BoardContext _dbBoard;
        private readonly ColumnContext _dbColumn;
        private readonly TodolistContext _dbTodo;

        public CardRepository(CardContext context, BoardContext bc, ColumnContext cc, TodolistContext tc)
        {
            _db = context;
            _dbBoard = bc;
            _dbColumn = cc;
            _dbTodo = tc;
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
            var board = _dbBoard.Boards.Find(card.BoardId);
            var column = _dbColumn.Columns.Find(card.ColumnId);
            var todolist = new Todolist
            {
                Title = "Todolist",
                Id = GetNextTodolistId(),
                TodoIds = ""
            };

            card.TodolistId = todolist.Id;
            card.Id = GetNextCardId();
            board.AddCardId(card.Id);
            column.AddCardId(card.Id);

            _dbBoard.Boards.Update(board);
            _dbColumn.Columns.Update(column);
            _db.Cards.Add(card);
            _dbTodo.Todolists.Add(todolist);

            _dbTodo.SaveChanges();
            _dbBoard.SaveChanges();
            _dbColumn.SaveChanges();
            _db.SaveChanges();
            
            return card.Id;
        }

        public void ChangeCard(int id, Card card)
        {
            if (card == null) throw new Exception("ChangeCard method error: Card is null");
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
            var board = _dbBoard.Boards.Find(card.BoardId);
            var column = _dbColumn.Columns.Find(card.ColumnId);
            
            board.DeleteCardId(card.Id);
            column.DeleteCardId(card.Id);

            _dbBoard.Boards.Update(board);
            _dbColumn.Columns.Update(column);
            _db.Cards.Remove(card);
            _dbBoard.SaveChanges();
            _dbColumn.SaveChanges();
            _db.SaveChanges();
        }

        private int GetNextCardId()
        {
            var ids = _db.Cards.ToList().Select(x => x.Id).ToList();
            return ids.Any() ? ids.Max() + 1 : 1;
        }
        
        private int GetNextTodolistId()
        {
            var ids = _dbTodo.Todolists.ToList().Select(x => x.Id).ToList();
            return ids.Any() ? ids.Max() + 1 : 1;
        }
    }
}
