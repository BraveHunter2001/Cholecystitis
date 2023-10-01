using DAL.Model;

namespace DAL.Repositories;

public class CholecystitRepository : IRepository<Cholecystit>
{
    CholecystitisContext _context;

    public CholecystitRepository(CholecystitisContext context)
    {
        _context = context;
    }

    public Cholecystit GetById(int id) => GetAll().FirstOrDefault(x => x.Id == id);

    public IEnumerable<Cholecystit> GetAll() => _context.Cholecystits;

    public void Add(Cholecystit entity)
    {
        _context.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Cholecystit entity)
    {
        var chol = GetById(entity.Id);
        if (chol is null) return;

        chol.Degree = entity.Degree;
        chol.Type = entity.Type;
        chol.BacteriasIds = entity.BacteriasIds;
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
    }

    public void Delete(int id)
    {
        var chol = GetById(id);
        if (chol is null) return;

        _context.Remove(chol);
        _context.SaveChanges();
    }
}