using System.Collections.Generic;

namespace ng2trello_backend.Models.Serializable
{
    public class SerTodolist : SerializableBase
    {
        public int Id { get; set; }
        public List<SerTodo> Todos { get; set; }
        public string Title { get; set; }
    }
}
