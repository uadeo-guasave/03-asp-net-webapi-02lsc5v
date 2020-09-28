using Microsoft.EntityFrameworkCore;

namespace myapi.Models
{
  public class DemoDbContext : DbContext
  {
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseSqlite("Data Source=Db/demo.db");
      base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
      base.OnModelCreating(modelBuilder);
    }

  }
}