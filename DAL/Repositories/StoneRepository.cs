using DAL.Model;

namespace DAL.Repositories;

public class StoneRepository : IRepository<Stone>
{
    CholecystitisContext _context;

    public StoneRepository(CholecystitisContext context)
    {
        _context = context;
    }

    public Stone GetById(Guid id) => GetAll().FirstOrDefault(x => x.Id == id);

    public IEnumerable<Stone> GetAll() => _context.Stones;

    public void Add(Stone entity)
    {
        _context.Stones.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Stone entity)
    {
        var stone = GetById(entity.Id);
        if (stone is null) return;

        stone.Type = entity.Type;
        stone.Сomposition = stone.Сomposition;
        stone.Color = entity.Color;
        stone.Cholecystit = entity.Cholecystit;
        stone.CholecystitId = entity.CholecystitId;

        _context.Stones.Update(stone);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var stone = GetById(id);
        if (stone is null) return;
        _context.Stones.Remove(stone);
        _context.SaveChanges();
    }
}