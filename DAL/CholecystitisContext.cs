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
    }
    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Cholecystit>()
            .HasOne(c => c.Patient)
            .WithOne(p => p.Cholecystit)
            .HasForeignKey<Patient>(p => p.CholecystitId);

        builder.Entity<Cholecystit>()
            .HasMany(c => c.Stones)
            .WithOne(s => s.Cholecystit)
            .HasForeignKey(s => s.CholecystitId);


        builder.Entity<Cholecystit>()
            .HasMany(c => c.Bacterias)
            .WithMany(b => b.Cholecystits);
            

        builder.Entity<Bacterium>()
          .HasData( new[] { 
              new { Id = Guid.NewGuid(), Name = "Escherichia coli" }, 
              new { Id = Guid.NewGuid(), Name = "Klebsiella spp" },
              new { Id = Guid.NewGuid(), Name = "Enterobacter spp" },
              new { Id = Guid.NewGuid(), Name = "Bacteroides" },
              new { Id = Guid.NewGuid(), Name = "Clostridia spp" },
              new { Id = Guid.NewGuid(), Name = "Fusobacterium spp" },
              new { Id = Guid.NewGuid(), Name = "enterococci" },
          });

        

        base.OnModelCreating(builder);
    }
}