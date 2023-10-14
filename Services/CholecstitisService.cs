using DAL.DTO;
using DAL.Mapper;
using DAL.Model;
using DAL.Model.Enum;
using DAL.Repositories;

namespace Services;

public interface ICholecystitsService
{
    public Cholecystit Create(CholecystitDTO cholecystit);
    public Cholecystit GetCholecystit(Guid id);
    public void Update(Cholecystit cholecystit);
    public void Update(Guid id, CholecystitDTO cholecystit);
    public void Delete(Guid id);
}

public class CholecystitsService : ICholecystitsService
{
    private readonly IRepository<Cholecystit> _repository;
    private readonly IStoneService _stoneService;
    private readonly IPatientService _patientService;
    private readonly IBacteriumService _bacteriumService;

    public CholecystitsService(IRepository<Cholecystit> repository, IStoneService stoneService, IPatientService patientService, IBacteriumService bacteriumService)
    {
        _repository = repository;
        _stoneService = stoneService;
        _patientService = patientService;
        _bacteriumService = bacteriumService;
    }

    public Cholecystit Create(CholecystitDTO cholecystit)
    {
        var id = Guid.NewGuid();

        var bacterias = cholecystit
            .BacteriesID?
            .Select(_bacteriumService.GetById)
            .ToList();

        var pat = cholecystit.Patient.ToPatient(Guid.NewGuid(), id);
        var stones = cholecystit.Stones.Select(stoneDto => stoneDto.ToStone(Guid.NewGuid(), id)).ToList();

        var chol = new Cholecystit()
        {
            Id = id,
            DegreeCholestits = cholecystit.Degree ?? DegreeCholestits.Acute,
            Type = cholecystit.Type ?? CholecystitType.Calculous,
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

    public void Update(Guid id, CholecystitDTO cholecystit)
    {
        var res = GetCholecystit(id);
        if (res is null) return;

        if (cholecystit.Degree.HasValue) res.DegreeCholestits = cholecystit.Degree.Value;
        if (cholecystit.Type.HasValue) res.Type = cholecystit.Type.Value;

        if (!string.IsNullOrWhiteSpace(cholecystit.Symptoms)) res.Symptoms = cholecystit.Symptoms;
        if (!string.IsNullOrWhiteSpace(cholecystit.Pathophysiology)) res.Pathophysiology = cholecystit.Pathophysiology;
        if (!string.IsNullOrWhiteSpace(cholecystit.Histology)) res.Histology = cholecystit.Histology;
        if (!string.IsNullOrWhiteSpace(cholecystit.CausedComplications)) res.CausedComplications = cholecystit.CausedComplications;
        if (!string.IsNullOrWhiteSpace(cholecystit.Treatment)) res.Treatment = cholecystit.Treatment;

        if (cholecystit.Patient is not null)
            res.Patient = cholecystit.Patient.ToPatient(res.Patient.Id, res.Id);

        if (cholecystit.Stones is not null)
        {
            foreach (var stone in res.Stones)
                _stoneService.Remove(stone.Id);

            res.Stones = cholecystit.Stones.Select(s => s.ToStone(Guid.NewGuid(), res.Id)).ToList();
        }

        if (cholecystit.BacteriesID is not null)
            res.Bacterias = _bacteriumService.GetById(cholecystit.BacteriesID).ToList();

        _repository.Update(res);
    }

    public void Delete(Guid id) => _repository.Delete(id);
}