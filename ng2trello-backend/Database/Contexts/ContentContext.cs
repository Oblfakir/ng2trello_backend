using Microsoft.EntityFrameworkCore;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Contexts
{
  public class ContentContext: DbContext
  {
    public ContentContext(DbContextOptions<ContentContext> options) : base(options) { }
    public DbSet<Content> Contents { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Content>().HasKey(m => m.Id);
      base.OnModelCreating(builder);
    }
  }
}
