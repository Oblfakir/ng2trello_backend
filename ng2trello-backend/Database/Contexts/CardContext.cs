using Microsoft.EntityFrameworkCore;
using ng2trello_backend.Models;

namespace ng2trello_backend.Database.Contexts
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options) : base(options) { }
        public DbSet<Card> Cards { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Card>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
