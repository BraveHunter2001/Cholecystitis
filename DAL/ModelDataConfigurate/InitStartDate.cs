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

    private static List<LocalizationDictionary> localizations = new List<LocalizationDictionary>()
    {
        new ("SuccessfulCreate",
            "Холецистит был успешно СОЗДАН с id",
            "Cholecystit was successful CREATE with id",
            "Cholecystit buvo sėkmingai sukurti su id" ),

        new ("BadCreate",
            "Ошибка созадния холестицита",
            "Error create cholecystit",
            "Klaida sukurti cholecystit" ),


        new ("BadGet",
            "Модель не найдена с Id = ",
            "Model didn't found with id = ",
            "Modelis nebuvo rastas su id = " ),


        new ("SuccessfulUpdate",
            "Холецистит был успешнно ИЗМЕНЕН с id",
            "Cholecystit was successful UPDATE with id",
            "Cholecystit buvo sėkmingai atnaujinti su id" ),

        new ("BadUpdate",
            "Ошибка изменения холестицита",
            "Error update cholecystit",
            "Klaida atnaujinti cholecystit" ),

        new ("SuccessfulDelete",
            "Холецистит был успешнно удален с id",
            "Cholecystit was successful delete with id",
            "Cholecystit buvo sėkmingai ištrinti su id" ),

        new ("BadDelete",
            "Ошибка удаления холестицита",
            "Error delete cholecystit",
            "Klaida ištrinti cholecystit" ),

        new ("Create", "Создать холестецит", "Create cholecystits", "sukurti tulžies pūslės akmenligę"),
        new ("Update", "Изменить данные холестецит", "Update cholecystits", "atnaujinti cholestis"),
        new ("Delete", "Удалить", "Delete cholecystits", "Pašalinti tulžies pūslės akmenligę"),

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

        builder.Entity<LocalizationDictionary>()
            .HasData(localizations);
    }
}