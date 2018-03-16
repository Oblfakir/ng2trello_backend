using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.Entities
{
    public class Comment
    {
        public Comment()
        {

        }

        public Comment(SerComment comment)
        {
            Id = comment.Id;
            UserId = comment.UserId;
            Text = comment.Text;
            Data = comment.Data;
            CardId = comment.CardId;
        }

        public void CopyProps(Comment comment)
        {
            UserId = comment.UserId;
            Text = comment.Text;
            Data = comment.Data;
            CardId = comment.CardId;
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public int? CardId { get; set; }
        public string Text { get; set; }
        public string Data { get; set; }
    }
}
