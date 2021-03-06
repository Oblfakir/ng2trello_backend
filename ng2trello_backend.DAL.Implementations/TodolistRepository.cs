﻿using System;
using System.Collections.Generic;
using System.Linq;
using ng2trello_backend.DAL.Implementations.Contexts;
using ng2trello_backend.DAL.Interfaces;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Implementations
{
    public class TodolistRepository : ITodolistRepository
    {
        private readonly TodolistContext _db;

        public TodolistRepository(TodolistContext db)
        {
            _db = db;
        }

        public int AddTodolist(Todolist todolist)
        {
            if (todolist == null) throw new Exception("AddTodolist method error: Todolist is null");
            _db.Todolists.Add(todolist);
            _db.SaveChanges();
            return todolist.Id;
        }

        public List<Todolist> GetAllTodolists()
        {
            return _db.Todolists.ToList();
        }

        public Todolist GetTodolistById(int id)
        {
            var todolist = _db.Todolists.Find(id);
            if (todolist == null) throw new Exception($"GetTodolistById method error: No todolist with id {id}");
            return todolist;
        }

        public void ChangeTodolist(int id, Todolist todolist)
        {
            if (todolist == null) throw new Exception("ChangeTodolist method error: Todolist is null");
            var changingTodolist = _db.Todolists.Find(id);
            if (changingTodolist == null) throw new Exception($"ChangeTodolist method error: No todolist with id {id}");
            todolist.Id = id;
            _db.Todolists.Update(todolist);
            _db.SaveChanges();
        }

        public void DeleteTodolist(int id)
        {
            var todolist = _db.Todolists.Find(id);
            if (todolist == null) throw new Exception($"DeleteTodolist method error: No todolist with id {id}");
            _db.Todolists.Remove(todolist);
            _db.SaveChanges();
        }

        public int AddTodo(int todolistid, Todo todo)
        {
            var todolist = _db.Todolists.Find(todolistid);
            if (todolist == null) throw new Exception($"AddTodo method error: No todolist with id {todolistid}");
            _db.Todos.Add(todo);
            _db.SaveChanges();
            todolist.AddTodoId(todo.Id);
            ChangeTodolist(todolistid, todolist);
            return todo.Id;
        }

        public void DeleteTodo(int todolistid, int id)
        {
            var todolist = _db.Todolists.Find(todolistid);
            if (todolist == null) throw new Exception($"DeleteTodo method error: No todolist with id {todolistid}");
            var todo = _db.Todos.Find(id);
            if (todo == null) throw new Exception($"DeleteTodo method error: No todo in todolist with id {id}");
            todolist.DeleteTodoId(id);
            _db.Todos.Remove(_db.Todos.Find(id));
            _db.SaveChanges();
            ChangeTodolist(todolistid, todolist);
        }

        public void ChangeTodo(int todolistid, int id, Todo todo)
        {
            var todolist = _db.Todolists.Find(todolistid);
            if (todolist == null) throw new Exception($"ChangeTodo method error: No todolist with id {todolistid}");
            var changingTodo = _db.Todos.Find(id);
            if (changingTodo == null) throw new Exception($"ChangeTodo method error: No todo in todolist with id {id}");
            changingTodo.Status = todo.Status;
            changingTodo.Text = todo.Text;
            _db.Todos.Update(changingTodo);
            _db.SaveChanges();
        }

        public Todo GetTodoById(int id)
        {
            return _db.Todos.Find(id);
        }

        public List<Todo> GetTodosByIdArray(List<int> ids)
        {
            return ids.Select(id => _db.Todos.Find(id)).Where(todo => todo != null).ToList();
        }
    }
}
