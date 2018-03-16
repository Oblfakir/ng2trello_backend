using Microsoft.EntityFrameworkCore;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Implementations.Contexts
{
    public class TodolistContext : DbContext
    {
        public TodolistContext(DbContextOptions<TodolistContext> options) : base(options) { }

        public DbSet<Todolist> Todolists { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Todolist>().HasKey(m => m.Id);
            builder.Entity<Todo>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
