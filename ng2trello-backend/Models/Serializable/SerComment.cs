namespace ng2trello_backend.Models.Serializable
{
    public class SerComment : SerializableBase
    {
        public SerComment()
        {

        }

        public SerComment(Comment comment)
        {
            Id = comment.Id;
            UserId = comment.UserId;
            Text = comment.Text;
            Data = comment.Data;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public string Data { get; set; }
    }
}
