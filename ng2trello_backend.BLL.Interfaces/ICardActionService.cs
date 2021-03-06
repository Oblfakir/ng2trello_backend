﻿using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Interfaces
{
    public interface ICardActionService
    {
        string GetCardActionsByCardId(int id);
        string GetCardActionById(int id);
        string GetAllCardActions();
        int AddCardAction(SerCardAction cardAction);
        void DeleteCardAction(int id);
        void ChangeCardAction(int id, SerCardAction cardAction);
    }
}
