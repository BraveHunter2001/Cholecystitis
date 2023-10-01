using Microsoft.Extensions.DependencyInjection;

namespace Services.DI;

public static class DependencyInjection
{
    public static void AddCholicystitsServices(this IServiceCollection servicies)
    {
        servicies.AddScoped<IBacteriumService, BacteriumService>();
        servicies.AddScoped<IStoneService, StoneService>(); 
    }
}