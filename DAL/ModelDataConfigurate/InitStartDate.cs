using DAL.Model;
using DAL.Model.Enum;
using Microsoft.EntityFrameworkCore;

namespace DAL.ModelDataConfigurate;

public static class InitStartDate
{
    private static List<Guid> CholecystitsGuids = new()
    {
        new Guid("6D6D45AD-E108-47AE-AD93-C561EA7E7277"),
        Guid.NewGuid(),
        Guid.NewGuid(),
    };

    private static List<Bacterium> Bacteriums = new()
    {
        new Bacterium { Id = Guid.NewGuid(), Name = "Escherichia coli" },
        new Bacterium { Id = Guid.NewGuid(), Name = "Klebsiella spp" },
        new Bacterium { Id = Guid.NewGuid(), Name = "Enterobacter spp" },
        new Bacterium { Id = Guid.NewGuid(), Name = "Bacteroides" },
        new Bacterium { Id = Guid.NewGuid(), Name = "Clostridia spp" },
        new Bacterium { Id = Guid.NewGuid(), Name = "Fusobacterium spp" },
        new Bacterium { Id = Guid.NewGuid(), Name = "enterococci" },
    };

    private static List<Patient> Patients = new()
    {
        new Patient { Id = Guid.NewGuid(), Name = "Ilya", Age = 22, Gender = Gender.Male, RiskFactors = "None", CholecystitId = CholecystitsGuids[0] },
        new Patient { Id = Guid.NewGuid(), Name = "Arslan", Age = 22, Gender = Gender.Male, RiskFactors = "None", CholecystitId = CholecystitsGuids[1] },
        new Patient { Id = Guid.NewGuid(), Name = "Lena", Age = 30, Gender = Gender.Female, RiskFactors = "Smoking", CholecystitId = CholecystitsGuids[2] },
    };

    private static List<Stone> Stones = new()
    {
        new Stone { Id = Guid.NewGuid(), Color = "Red", Type = StoneType.Cholesterol, CholecystitId = CholecystitsGuids[0] },
        new Stone { Id = Guid.NewGuid(), Color = "Red", Type = StoneType.Cholesterol, CholecystitId = CholecystitsGuids[1] },
        new Stone { Id = Guid.NewGuid(), Color = "Red-yellow", Type = StoneType.Cholesterol, CholecystitId = CholecystitsGuids[1] },
        new Stone { Id = Guid.NewGuid(), Color = "Stone", Type = StoneType.Pigmented, CholecystitId = CholecystitsGuids[2] },
        new Stone { Id = Guid.NewGuid(), Color = "Red-yellow", Type = StoneType.Pigmented, CholecystitId = CholecystitsGuids[2] },
        new Stone { Id = Guid.NewGuid(), Color = "Red-yellow", Type = StoneType.Cholesterol, CholecystitId = CholecystitsGuids[2] }
    };

    private static List<Cholecystit> Cholecystits = new()
    {
        new Cholecystit
        {
            Id = CholecystitsGuids[0],
            DegreeCholestits = DegreeCholestits.Acute,
            Type = CholecystitType.Calculous,

            Symptoms = "None",
            Pathophysiology = "None",
            Histology = "None",
            CausedComplications = "None",
            Treatment = "None",
        },

        new Cholecystit
        {
            Id = CholecystitsGuids[1],
            DegreeCholestits = DegreeCholestits.Chronic,
            Type = CholecystitType.Emphysematous,

            Symptoms = "None",
            Pathophysiology = "None",
            Histology = "None",
            CausedComplications = "None",
            Treatment = "None",
        },

        new Cholecystit
        {
            Id = CholecystitsGuids[2],
            DegreeCholestits = DegreeCholestits.Acute,
            Type = CholecystitType.Emphysematous,

            Symptoms = "None",
            Pathophysiology = "None",
            Histology = "None",
            CausedComplications = "None",
            Treatment = "None",
        }
    };

    public static void Init(this ModelBuilder builder)
    {
        builder.Entity<Bacterium>()
            .HasData(Bacteriums);

        builder.Entity<Patient>()
            .HasData(Patients);

        builder.Entity<Stone>()
            .HasData(Stones);

        builder.Entity<Cholecystit>()
            .HasData(Cholecystits);
    }
}