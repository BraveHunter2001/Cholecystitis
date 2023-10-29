using DAL.Model;
using DAL.Model.Enum;
using DAL.ModelDataConfigurate;
using Microsoft.EntityFrameworkCore;

namespace DAL;

public class CholecystitisContext : DbContext
{
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Stone> Stones { get; set; }
    public DbSet<Bacterium> Bacteriums { get; set; }
    public DbSet<Cholecystit> Cholecystits { get; set; }
    public DbSet<LocalizationDictionary> LocalizationDictionary { get; set; }

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

        builder.Entity<LocalizationDictionary>().HasKey(p => p.Key);

        builder.Init();

        base.OnModelCreating(builder);
    }
}