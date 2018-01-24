using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Interfaces;

namespace ng2trello_backend.Services.Implementations
{
    public class TodoService : ITodoService
    {
        private readonly ITodolistRepository _repository;

        public TodoService(ITodolistRepository repository)
        {
            _repository = repository;
        }

        public int AddTodo(int todolistid, SerTodo todo)
        {
            return _repository.AddTodo(todolistid, new Todo(todo));
        }

        public void DeleteTodo(int todolistid, int id)
        {
            _repository.DeleteTodo(todolistid, id);
        }

        public void ChangeTodo(int todolistid, int id, SerTodo todo)
        {
            _repository.ChangeTodo(todolistid, id, new Todo(todo));
        }
    }
}
