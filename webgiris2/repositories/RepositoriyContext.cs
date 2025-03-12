using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using webgiris2.Models;
using webgiris2.repositories.Config;

namespace webgiris2.repositories
{
    public class RepositoriyContext:DbContext
    {
        public RepositoriyContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<dene> Denes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new deneConfig());
        }
    }
}
