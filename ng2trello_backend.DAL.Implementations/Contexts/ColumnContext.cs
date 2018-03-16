using Microsoft.EntityFrameworkCore;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Implementations.Contexts
{
    public class ColumnContext : DbContext
    {
        public ColumnContext(DbContextOptions<ColumnContext> options) : base(options) { }
        public DbSet<Column> Columns { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Column>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
