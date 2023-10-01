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

        servicies.AddTransient<IRepository<Bacterium>,BacteriumRepository>();
    }
}