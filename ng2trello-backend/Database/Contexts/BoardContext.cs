using Microsoft.EntityFrameworkCore;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Contexts
{
    public class BoardContext : DbContext
    {
        public BoardContext(DbContextOptions<BoardContext> options) : base(options)
        {
        }

        public DbSet<Board> Boards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Board>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}