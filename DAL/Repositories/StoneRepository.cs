using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class StoneRepository : IRepository<Stone>
{
    CholecystitisContext _context;

    public StoneRepository(CholecystitisContext context)
    {
        _context = context;
    }

    public Stone GetById(Guid id) => GetAll().FirstOrDefault(x => x.Id == id);

    public IEnumerable<Stone> GetAll() => _context.Stones.Include(p => p.Cholecystit);

    public void Add(Stone entity)
    {
        _context.Stones.Add(entity);
        _context.SaveChanges();
    }

    public Stone Update(Stone entity)
    {
        var stone = GetById(entity.Id);
        if (stone is null) return null;

        stone.Type = entity.Type;
        stone.Composition = stone.Composition;
        stone.Color = entity.Color;
        stone.Cholecystit = entity.Cholecystit;
        stone.CholecystitId = entity.CholecystitId;

        _context.Stones.Update(stone);
        _context.SaveChanges();

        return stone;
    }

    public Stone Delete(Guid id)
    {
        var stone = GetById(id);
        if (stone is null) return null;
        _context.Stones.Remove(stone);
        _context.SaveChanges();

        return stone;
    }
}