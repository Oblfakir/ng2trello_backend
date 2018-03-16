using ng2trello_backend.BLL.Interfaces;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities;
using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Implementations
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
