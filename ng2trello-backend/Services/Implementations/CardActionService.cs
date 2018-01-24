using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Extensions;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Interfaces;

namespace ng2trello_backend.Services.Implementations
{
  public class CardActionService: ICardActionService
  {
    private readonly ICardActionRepository _repository;

    public CardActionService(ICardActionRepository repository)
    {
      _repository = repository;
    }

    public string GetCardActionsByCardId(int id)
    {
      return _repository.GetCardActionsByCardId(id).Serialize();
    }

    public string GetCardActionById(int id)
    {
      return new SerCardAction(_repository.GetCardActionById(id)).Serialize();
    }

    public string GetAllCardActions()
    {
      return _repository.GetAllCardActions().Serialize();
    }

    public int AddCardAction(SerCardAction cardAction)
    {
      return _repository.AddCardAction(new CardAction(cardAction));
    }

    public void DeleteCardAction(int id)
    {
      _repository.DeleteCardAction(id);
    }

    public void ChangeCardAction(int id, SerCardAction cardAction)
    {
      _repository.ChangeCardAction(id, new CardAction(cardAction));
    }
  }
}
