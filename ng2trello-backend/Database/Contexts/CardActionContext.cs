using Microsoft.EntityFrameworkCore;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Contexts
{
  public class CardActionContext: DbContext
  {
    public CardActionContext(DbContextOptions<CardActionContext> options) : base(options) { }
    public DbSet<CardAction> CardActions { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<CardAction>().HasKey(m => m.Id);
      base.OnModelCreating(builder);
    }
  }
}
