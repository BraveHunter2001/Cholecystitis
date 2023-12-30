using DAL.Model;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RestSharp;
using System.Net.Http;

namespace DAL.DI;

public static class DependencyInjection
{
    public static void AddCholecystitisContext(this IServiceCollection servicies)
    {
        var client = new RestClient("http://host.docker.internal:5002");
        var request = new RestRequest("api/Configurations/GetDbConnect");

        var response = client.GetAsync<string>(request).Result;

        if (response != null) { Console.WriteLine("Was getting connection string from congfig-api"); }

        servicies.AddDbContext<CholecystitisContext>(
            opt => opt.UseNpgsql(response)
        );

        servicies.AddScoped<IRepository<Bacterium>, BacteriumRepository>();
        servicies.AddScoped<IRepository<Stone>, StoneRepository>();
        servicies.AddScoped<IRepository<Patient>, PatinetRepository>();
        servicies.AddScoped<IRepository<Cholecystit>, CholecystitRepository>();
        servicies.AddScoped<IRepository<LocalizationDictionary>, LocalizationDictionaryRepository>();
    }
}