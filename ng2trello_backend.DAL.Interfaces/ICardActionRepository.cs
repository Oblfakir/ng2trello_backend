using System.Collections.Generic;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Interfaces
{
    public interface ICardActionRepository
    {
        List<CardAction> GetCardActionsByCardId(int id);
        List<CardAction> GetAllCardActions();
        CardAction GetCardActionById(int id);
        int AddCardAction(CardAction cardAction);
        void DeleteCardAction(int id);
        void ChangeCardAction(int id, CardAction cardAction);
    }
}
