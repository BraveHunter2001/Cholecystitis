using DAL.Model;
using DAL.Model.Enum;
using DAL.Repositories;

namespace Services;

public interface IPatientService
{
    public void Create(string name, int age, Gender gender, string rickFactors, Cholecystit cholecystit);
    public Patient GetPatient(int id);
}

public class PatientService : IPatientService
{
    private readonly IRepository<Patient> _repository;

    public PatientService(IRepository<Patient> repository)
    {
        _repository = repository;
    }

    public void Create(string name, int age, Gender gender, string rickFactors, Cholecystit cholecystit)
    {
        _repository.Add(new Patient
        {
            Name = name,
            Age = age,
            Gender = gender,
            Cholecystit = cholecystit,
            CholecystitId = cholecystit.Id,
            RiskFactors = rickFactors
        });
    }

    public Patient GetPatient(int id) => _repository.GetById(id);

}