using ng2trello_backend.Models.Serializable;

namespace ng2trello_backend.Services.Interfaces
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
