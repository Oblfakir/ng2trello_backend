﻿using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.Entities
{
    public class Todo
    {
        public Todo()
        {

        }

        public Todo(SerTodo todo)
        {
            Id = todo.Id;
            Text = todo.Text;
            Status = todo.Status.ToString();
        }

        public int Id { get; set; }
        public string Text { get; set; }
        public string Status { get; set; }
    }
}
