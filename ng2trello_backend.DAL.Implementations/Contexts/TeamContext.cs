using Microsoft.EntityFrameworkCore;
using ng2trello_backend.Entities;

namespace ng2trello_backend.DAL.Implementations.Contexts
{
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) : base(options) { }
        public DbSet<Team> Teams { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Team>().HasKey(m => m.Id);
            base.OnModelCreating(builder);
        }
    }
}
