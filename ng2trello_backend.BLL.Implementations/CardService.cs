using ng2trello_backend.BLL.Implementations.Extensions;
using ng2trello_backend.BLL.Interfaces;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities;
using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Implementations
{
    public class CardService : ICardService
    {
        private readonly ICardRepository _repository;

        public CardService(ICardRepository repository)
        {
            _repository = repository;
        }

        public string GetAllCards()
        {
            return _repository.GetAllCards().Serialize();
        }

        public string GetCardsByBoardId(int id)
        {
            return _repository.GetCardsByBoardId(id).Serialize();
        }

        public string GetCardsByColumnId(int id)
        {
            return _repository.GetCardsByColumnId(id).Serialize();
        }

        public string GetCardById(int id)
        {
            return new SerCard(_repository.GetCardById(id)).Serialize();
        }

        public int AddCard(SerCard card)
        {
            return _repository.AddCard(new Card(card));
        }

        public void ChangeCard(int id, SerCard card)
        {
            _repository.ChangeCard(id, new Card(card));
        }

        public void DeleteCard(int id)
        {
            _repository.DeleteCard(id);
        }
    }
}
