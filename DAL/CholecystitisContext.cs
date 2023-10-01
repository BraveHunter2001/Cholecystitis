using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class CholecystitisContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Stone> Stones { get; set; }
    public DbSet<Bacterium> Bacteriums { get; set; }
    public DbSet<Cholecystit> Cholecystits { get; set; }

    public CholecystitisContext(DbContextOptions<CholecystitisContext> option) : base(option)
    {
        Database.EnsureCreated();
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Patient>().HasOne(p => p.Cholecystit)
            .WithOne(c => c.Patient)
            .HasForeignKey<Patient>(p => p.CholecystitId);

        builder.Entity<Bacterium>().HasKey(b => b.Id);

        builder.Entity<Bacterium>()
            .Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder.Entity<Bacterium>()
          .HasData( new[] { 
              new { Id = 1, Name = "Escherichia coli" }, 
              new { Id = 2, Name = "Klebsiella spp" },
              new { Id = 3, Name = "Enterobacter spp" },
              new { Id = 4, Name = "Bacteroides" },
              new { Id = 5, Name = "Clostridia spp" },
              new { Id = 6, Name = "Fusobacterium spp" },
              new { Id = 7, Name = "enterococci" },
          });

        

        base.OnModelCreating(builder);
    }
}