namespace ng2trello_backend.Entities.Serializable
{
    public class SerContent : SerializableBase
    {
        public SerContent()
        {

        }

        public SerContent(Content content)
        {
            Id = content.Id;
            CardId = content.CardId;
            Text = content.Text;
            ImageUrl = content.ImageUrl;
        }

        public int Id { get; set; }
        public int CardId { get; set; }
        public string Text { get; set; }
        public string ImageUrl { get; set; }
    }
}
