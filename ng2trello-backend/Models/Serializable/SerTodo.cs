namespace ng2trello_backend.Models.Serializable
{
    public class SerTodo : SerializableBase
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public bool Status { get; set; }

        public SerTodo()
        {

        }

        public SerTodo(Todo todo)
        {
            Id = todo.Id;
            Text = todo.Text;
            Status = bool.Parse(todo.Status);
        }
    }
}
