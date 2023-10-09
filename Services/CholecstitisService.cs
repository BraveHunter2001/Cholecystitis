using DAL.DTO;
using DAL.Model;
using DAL.Repositories;

namespace Services;

public interface ICholecstitisService
{
    public Cholecystit Create(CholestitsDTO cholecystit);
    public Cholecystit GetCholecystit(Guid id);
    public void Update(Cholecystit cholecystit);
    public void Delete(Guid id);
}

public class CholecstitisService : ICholecstitisService
{
    private readonly IRepository<Cholecystit> _repository;
    private readonly IStoneService _stoneService;
    private readonly IPatientService _patientService;
    private readonly IBacteriumService _bacteriumService;

    public CholecstitisService(IRepository<Cholecystit> repository, IStoneService stoneService, IPatientService patientService, IBacteriumService bacteriumService)
    {
        _repository = repository;
        _stoneService = stoneService;
        _patientService = patientService;
        _bacteriumService = bacteriumService;
    }

    public Cholecystit Create(CholestitsDTO cholecystit)
    {
        var id = Guid.NewGuid();

        var bacterias = cholecystit
            .BacteriesID
            .Select(_bacteriumService.GetById)
            .ToList();

        var pat = new Patient
        {
            Id = Guid.NewGuid(),
            Name = cholecystit.Patient.Name,
            Age = cholecystit.Patient.Age,
            Gender = cholecystit.Patient.Gender,
            RiskFactors = cholecystit.Patient.RiskFactors,
            CholecystitId = id,
        };

        var stones = cholecystit.Stones
            .Select(stone => new Stone { 
                Id = Guid.NewGuid(),
                Type= stone.Type,
                Color = stone.Color,
                Сomposition= stone.Сomposition,
                CholecystitId = id,
            })
            .ToList();

        var chol = new Cholecystit()
        {
            Id = id,
            Degree = cholecystit.Degree,
            Type = cholecystit.Type,
            CausedComplications = cholecystit.CausedComplications,
            Histology = cholecystit.Histology,
            Symptoms = cholecystit.Symptoms,
            Pathophysiology = cholecystit.Pathophysiology,
            Treatment = cholecystit.Treatment,
            
            Bacterias = bacterias,
            Patient = pat,
            Stones = stones,
        };

        _repository.Add(chol);

        return chol;
    }

    public Cholecystit GetCholecystit(Guid id) 
    {
        var ch = _repository.GetById(id);


        return ch;
    }

    public void Update(Cholecystit cholecystit) => _repository.Update(cholecystit);

    public void Delete(Guid id) => _repository.Delete(id);
}