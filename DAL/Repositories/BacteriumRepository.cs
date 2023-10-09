using DAL.Model;

namespace DAL.Repositories;

public class BacteriumRepository : IRepository<Bacterium>
{
    private readonly CholecystitisContext _dbcontext;

    public BacteriumRepository(CholecystitisContext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public Bacterium GetById(Guid id) => _dbcontext.Bacteriums.FirstOrDefault(b => b.Id == id);
    public IEnumerable<Bacterium> GetAll() => _dbcontext.Bacteriums;

    public void Add(Bacterium entity)
    {
        _dbcontext.Bacteriums.Add(entity);
        _dbcontext.SaveChanges();
    }

    public void Update(Bacterium entity)
    {
        var oldB = _dbcontext.Bacteriums.FirstOrDefault(b => b.Id == entity.Id);
        if (oldB is null) return;
        oldB.Cholecystits = entity.Cholecystits;
        oldB.Name = entity.Name;
        _dbcontext.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var oldB = _dbcontext.Bacteriums.FirstOrDefault(b => b.Id == id);
        if (oldB is null) return;
        _dbcontext.Remove(oldB);
        _dbcontext.SaveChanges();
    }
}