using Microsoft.EntityFrameworkCore;
using myapi.Entities;

namespace myapi.DbContexts
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
      modelBuilder.Entity<User>(u =>
      {
        u.HasIndex(i => i.Name).IsUnique();
        u.HasIndex(i => i.Email).IsUnique();

        u.Property(p => p.Id).HasColumnName("id");
        u.Property(p => p.Name).HasColumnName("name");
        u.Property(p => p.Password).HasColumnName("password");
        u.Property(p => p.Email).HasColumnName("email");
        u.Property(p => p.Firstname).HasColumnName("firstname");
        u.Property(p => p.Lastname).HasColumnName("lastname");
        u.Property(p => p.Gender).HasColumnName("gender");
      });

      base.OnModelCreating(modelBuilder);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Category> Categories { get; set; }

  }
}