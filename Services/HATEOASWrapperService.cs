using DAL.DTO;
using DAL.Model;

namespace Services;

public interface IHATEOASService
{
    public HATEOASWrapper<Cholecystit> BuildHATEOASGet(Cholecystit model, string lang);
}

public class HATEOASWrapperService: IHATEOASService
{
    private readonly ILocalizationService _localizationService;
    public HATEOASWrapperService(ILocalizationService localizationService)
    {
        _localizationService = localizationService;
    }
    public HATEOASWrapper<Cholecystit> BuildHATEOASGet(Cholecystit model, string lang)
    {
        Dictionary<string, HATEOASLink> hateoasGet = new()
        {
            { "self", new HATEOASLink{Link = $"https://localhost:5001/api/Cholecystitis/{model.Id}" } },
            {_localizationService.Localize("Create",lang), new HATEOASLink{Link = "https://localhost:5001/api/Cholecystitis/" } },
            {_localizationService.Localize("Update",lang), new HATEOASLink{Link = "https://localhost:5001/api/Cholecystitis/" } },
            {_localizationService.Localize("Delete",lang), new HATEOASLink{Link = "https://localhost:5001/api/Cholecystitis/" } },
        };

        return new HATEOASWrapper<Cholecystit> { Model= model, Links = hateoasGet };
    }

}
