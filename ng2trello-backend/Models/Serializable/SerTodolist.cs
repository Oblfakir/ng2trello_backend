using System.Collections.Generic;
using Newtonsoft.Json;

namespace ng2trello_backend.Models.Serializable
{
  public class SerTodolist: SerializableBase
  {
    public int Id { get; set; }
    public List<SerTodo> Todos { get; set; }
    public string Title { get; set; }
  }
}
