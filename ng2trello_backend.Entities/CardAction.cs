using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.Entities
{
    public class CardAction
    {
        public CardAction()
        {

        }

        public void CopyProps(CardAction cardAction)
        {
            CardId = cardAction.CardId;
            Text = cardAction.Text;
            ParticipantId = cardAction.ParticipantId;
        }

        public CardAction(SerCardAction cardAction)
        {
            Id = cardAction.Id;
            CardId = cardAction.CardId;
            Text = cardAction.Text;
            ParticipantId = cardAction.ParticipantId;
        }

        public int Id { get; set; }
        public int CardId { get; set; }
        public string Text { get; set; }
        public int ParticipantId { get; set; }
    }
}
