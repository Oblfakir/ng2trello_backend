namespace ng2trello_backend.Models.Serializable
{
  public class SerCardAction: SerializableBase
  {
    public SerCardAction()
    {

    }

    public SerCardAction(CardAction cardAction)
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
