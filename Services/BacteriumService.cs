using DAL.Model;
using DAL.Repositories;

namespace Services;

public interface IBacteriumService
{
    public Guid AddNew(string name);
    public List<Bacterium> GetAllBacterium();
    public Bacterium GetById(Guid id);
    public Bacterium[] GetById(Guid[] ids);
    public Bacterium GetByName(string name);
}

public class BacteriumService : IBacteriumService
{
    private readonly IRepository<Bacterium> _repository;

    public BacteriumService(IRepository<Bacterium> repository)
    {
        _repository = repository;
    }

    public Guid AddNew(string name)
    {
        var id = Guid.NewGuid();
        _repository.Add(new Bacterium { Id = id, Name = name });
        return id;
    }

    public List<Bacterium> GetAllBacterium() => _repository.GetAll().ToList();
    public Bacterium GetById(Guid id) => _repository.GetById(id);
    public Bacterium[] GetById(Guid[] ids) => ids.Select(GetById).ToArray();
    public Bacterium GetByName(string name) => _repository.GetAll().FirstOrDefault(b => b.Name == name);
}