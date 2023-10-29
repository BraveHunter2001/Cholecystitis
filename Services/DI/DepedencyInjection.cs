using Microsoft.Extensions.DependencyInjection;

namespace Services.DI;

public static class DependencyInjection
{
    public static void AddCholicystitsServices(this IServiceCollection servicies)
    {
        servicies.AddScoped<ILocalizationService, LocalizationService>();

        servicies.AddTransient<IBacteriumService, BacteriumService>();
        servicies.AddTransient<IStoneService, StoneService>(); 
        servicies.AddTransient<IPatientService, PatientService>();
        servicies.AddTransient<ICholecystitsService, CholecystitsService>();
        servicies.AddTransient<IHATEOASService, HATEOASWrapperService>();
    }
}