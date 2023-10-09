using DAL.Model;
using DAL.Model.Enum;
using DAL.Repositories;
using System.Xml.Linq;

namespace Services;

public interface IPatientService
{
    public Patient Create(string name, int age, Gender gender, string rickFactors);
    public Patient GetPatient(Guid id);
}

public class PatientService : IPatientService
{
    private readonly IRepository<Patient> _repository;

    public PatientService(IRepository<Patient> repository)
    {
        _repository = repository;
    }

    public Patient Create(string name, int age, Gender gender, string rickFactors)
    {
        var id = Guid.NewGuid();
        var patient = new Patient
        {
            Id = id,
            Name = name,
            Age = age,
            Gender = gender,
            RiskFactors = rickFactors,
        };

        _repository.Add(patient);

        return patient;
    }

    public Patient GetPatient(Guid id) => _repository.GetById(id);

}