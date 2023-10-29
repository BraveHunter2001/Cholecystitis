using DAL.Model;

namespace DAL.Repositories;

public class LocalizationDictionaryRepository : IRepository<LocalizationDictionary>
{

    CholecystitisContext _context;

    public LocalizationDictionaryRepository(CholecystitisContext context)
    {
        _context = context;
    }

    public LocalizationDictionary GetById(Guid id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<LocalizationDictionary> GetAll() => _context.LocalizationDictionary;


    public void Add(LocalizationDictionary entity)
    {
        throw new NotImplementedException();
    }

    public LocalizationDictionary Update(LocalizationDictionary entity)
    {
        throw new NotImplementedException();
    }

    public LocalizationDictionary Delete(Guid id)
    {
        throw new NotImplementedException();
    }
}