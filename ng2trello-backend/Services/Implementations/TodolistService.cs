using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.Database.Interfaces;
using ng2trello_backend.Extensions;
using ng2trello_backend.Models;
using ng2trello_backend.Models.Serializable;
using ng2trello_backend.Services.Interfaces;
using Newtonsoft.Json;

namespace ng2trello_backend.Services.Implementations
{
    public class TodolistService : ITodolistService
    {
        private readonly ITodolistRepository _repository;

        public TodolistService(ITodolistRepository repository)
        {
            _repository = repository;
        }

        public int AddTodolist(SerTodolist todolist)
        {
            todolist.Todos = new List<SerTodo>();
            return _repository.AddTodolist(new Todolist(todolist));
        }

        public string GetTodolistById(int id)
        {
            var todolist = _repository.GetTodolistById(id);
            return new SerTodolist
            {
                Id = id,
                Title = todolist.Title,
                Todos = _repository.GetTodosByIdArray(todolist.GetTodoIds()).Select(x => new SerTodo(x)).ToList()
            }.Serialize();
        }

        public string GetAllTodolists()
        {
            return _repository.GetAllTodolists().Select(x => new SerTodolist
            {
                Id = x.Id,
                Title = x.Title,
                Todos = _repository.GetTodosByIdArray(x.GetTodoIds()).Select(y => new SerTodo(y)).ToList()
            }).Serialize();
        }

        public void ChangeTodolist(int id, SerTodolist todolist)
        {
            _repository.ChangeTodolist(id, new Todolist(todolist));
        }

        public void DeleteTodolist(int id)
        {
            _repository.DeleteTodolist(id);
        }
    }
}
