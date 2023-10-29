using DAL.Model;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DAL.DI;

public static class DependencyInjection
{
    public static void AddCholecystitisContext(this IServiceCollection servicies)
    {
        servicies.AddDbContext<CholecystitisContext>(
            opt => opt.UseNpgsql("Server=postgres;Port=5432;Database=cholecystitis;User ID=pguser;Password=pgadmin;")
        );

        servicies.AddScoped<IRepository<Bacterium>,BacteriumRepository>();
        servicies.AddScoped<IRepository<Stone>, StoneRepository>();
        servicies.AddScoped<IRepository<Patient>, PatinetRepository>();
        servicies.AddScoped<IRepository<Cholecystit>,  CholecystitRepository>();
        servicies.AddScoped<IRepository<LocalizationDictionary>, LocalizationDictionaryRepository>();
    }
}