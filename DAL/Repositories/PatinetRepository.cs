using DAL.Model;

namespace DAL.Repositories;

public class PatinetRepository : IRepository<Patient>
{
    CholecystitisContext _context;

    public PatinetRepository(CholecystitisContext context)
    {
        _context = context;
    }

    public Patient GetById(Guid id) => GetAll().FirstOrDefault(x => x.Id == id);
    public IEnumerable<Patient> GetAll() => _context.Patients;

    public void Add(Patient entity)
    {
        _context.Patients.Add(entity);
        _context.SaveChanges();
    }

    public void Update(Patient entity)
    {
        var patient = GetById(entity.Id);
        if (patient is null) return;

        patient.Name = entity.Name;
        patient.Age = entity.Age;
        patient.Gender = entity.Gender;
        patient.RiskFactors = entity.RiskFactors;
        patient.CholecystitId = entity.CholecystitId;
        patient.Cholecystit = entity.Cholecystit;

        _context.Patients.Update(patient);
        _context.SaveChanges();
    }

    public void Delete(Guid id)
    {
        var patient = GetById(id);
        if (patient is null) return;

        _context.Remove(patient);
        _context.SaveChanges();
    }
}