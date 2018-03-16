using ng2trello_backend.Entities.Serializable;

namespace ng2trello_backend.BLL.Interfaces
{
    public interface ITodolistService
    {
        int AddTodolist(SerTodolist todolist);
        string GetTodolistById(int id);
        string GetAllTodolists();
        void ChangeTodolist(int id, SerTodolist todolist);
        void DeleteTodolist(int id);
    }
}
