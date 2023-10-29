using DAL.Model;
using DAL.Repositories;

namespace Services
{
    public interface ILocalizationService
    {
        public string Localize(string key, string language);
    }

    public class LocalizationService : ILocalizationService
    {
        IRepository<LocalizationDictionary> _repository;

        public LocalizationService(IRepository<LocalizationDictionary> repository)
        {
            _repository = repository;
        }

        public string Localize(string key, string language)
        {
            var dict = _repository.GetAll().FirstOrDefault(l => l.Key == key);

            if (dict is null) return key;

            var loc = language switch
            {
                "ru" => dict.RU,
                "en" => dict.EN,
                "it" => dict.IT,
                _ => dict.EN
            };
            return loc;
        }
    }
}