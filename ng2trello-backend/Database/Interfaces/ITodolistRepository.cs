using System.Collections.Generic;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Interfaces
{
    public interface ITodolistRepository
    {
        int AddTodolist(Todolist todolist);
        List<Todolist> GetAllTodolists();
        Todolist GetTodolistById(int id);
        void ChangeTodolist(int id, Todolist todolist);
        void DeleteTodolist(int id);

        int AddTodo(int todolistid, Todo todo);
        void DeleteTodo(int todolistid, int id);
        void ChangeTodo(int todolistid, int id, Todo todo);
        Todo GetTodoById(int id);
        List<Todo> GetTodosByIdArray(List<int> ids);
    }
}
