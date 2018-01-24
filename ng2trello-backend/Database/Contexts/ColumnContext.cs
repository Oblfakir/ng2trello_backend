using Microsoft.EntityFrameworkCore;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Contexts
{
  public class ColumnContext: DbContext
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
