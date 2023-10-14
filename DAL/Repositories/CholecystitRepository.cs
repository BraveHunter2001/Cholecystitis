using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class CholecystitRepository : IRepository<Cholecystit>
{
    CholecystitisContext _context;

    public CholecystitRepository(CholecystitisContext context)
    {
        _context = context;
    }

    public Cholecystit GetById(Guid id) => GetAll().FirstOrDefault(x => x.Id == id);

    public IEnumerable<Cholecystit> GetAll() => _context.Cholecystits
        .Include(c => c.Stones)
        .Include(c => c.Bacterias)
        .Include(c => c.Patient);

    public void Add(Cholecystit entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public Cholecystit Update(Cholecystit entity)
    {
        var chol = GetById(entity.Id);
        if (chol is null) return null;

        chol.DegreeCholestits = entity.DegreeCholestits;
        chol.Type = entity.Type;
        chol.Bacterias = entity.Bacterias;
        chol.CausedComplications = entity.CausedComplications;
        chol.Histology = entity.Histology;
        chol.Pathophysiology = entity.Pathophysiology;
        chol.Symptoms = entity.Symptoms;
        chol.Patient = entity.Patient;
        chol.Stones = entity.Stones;
        chol.Treatment = entity.Treatment;

        _context.Cholecystits.Update(chol);
        _context.SaveChanges();
        return chol;
    }

    public Cholecystit Delete(Guid id)
    {
        var chol = GetById(id);
        if (chol is null) return null;

        _context.Remove(chol);
        _context.SaveChanges();
        return chol;
    }
}