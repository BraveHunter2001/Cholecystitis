using DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public class PatinetRepository : IRepository<Patient>
{
    CholecystitisContext _context;

    public PatinetRepository(CholecystitisContext context)
    {
        _context = context;
    }

    public Patient GetById(Guid id) => GetAll().FirstOrDefault(x => x.Id == id);
    public IEnumerable<Patient> GetAll() => _context.Patients
        .Include(p => p.Cholecystit)
        .ThenInclude(c => c.Stones);

    public void Add(Patient entity)
    {
        _context.Patients.Add(entity);
        _context.SaveChanges();
    }

    public Patient Update(Patient entity)
    {
        var patient = GetById(entity.Id);
        if (patient is null) return null;

        patient.Name = entity.Name;
        patient.Age = entity.Age;
        patient.Gender = entity.Gender;
        patient.RiskFactors = entity.RiskFactors;
        patient.CholecystitId = entity.CholecystitId;
        patient.Cholecystit = entity.Cholecystit;

        _context.Patients.Update(patient);
        _context.SaveChanges();
        return patient;
    }

    public Patient Delete(Guid id)
    {
        var patient = GetById(id);
        if (patient is null) return null;

        _context.Remove(patient);
        _context.SaveChanges();
        return patient;
    }
}