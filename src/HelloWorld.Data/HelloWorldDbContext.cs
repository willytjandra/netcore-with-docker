using HelloWorld.Data.Domain;
using Microsoft.EntityFrameworkCore;

namespace HelloWorld.Data
{
    public class HelloWorldDbContext : DbContext
    {
        public HelloWorldDbContext(DbContextOptions<HelloWorldDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(HelloWorldDbContext).Assembly);
        }
    }
}
