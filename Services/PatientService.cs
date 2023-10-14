using DAL.DTO;
using DAL.Model;
using DAL.Model.Enum;
using DAL.Repositories;

namespace Services;

public interface IPatientService
{
    public Patient Create(string name, int age, Gender gender, string rickFactors);
    public Patient Create(string name, int age, Gender gender, string rickFactors, Guid cholecystitId);
    public Patient Create(PatientDto patientDto, Guid cholecystitId);
    public Patient GetPatient(Guid id);
    public void Removed(Guid id);
    public void Update(Patient patient);
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

    public Patient Create(string name, int age, Gender gender, string rickFactors, Guid cholecystitId)
    {
        var id = Guid.NewGuid();
        var patient = new Patient
        {
            Id = id,
            Name = name,
            Age = age,
            Gender = gender,
            RiskFactors = rickFactors,
            CholecystitId = cholecystitId,
        };

        _repository.Add(patient);

        return patient;
    }

    public Patient Create(PatientDto patientDto, Guid cholecystitId) => Create(patientDto.Name, patientDto.Age, patientDto.Gender, patientDto.RiskFactors, cholecystitId);

    public Patient GetPatient(Guid id) => _repository.GetById(id);
    public void Removed(Guid id) => _repository.Delete(id);
    public void Update(Patient patient) => _repository.Update(patient);
}