using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Interfaces
{
    public interface ITodoService
    {
        int AddTodo(int todolistid, SerTodo todo);
        void DeleteTodo(int todolistid, int id);
        void ChangeTodo(int todolistid, int id, SerTodo todo);
    }
}
