using DAL.Model;
using DAL.Repositories;

namespace Services;

public interface IBacteriumService
{
    public void AddNew(string name);
    public List<string> GetNamesAllBacterium();
    public Bacterium GetById(int id);
    public Bacterium GetByName(string name);
}

public class BacteriumService : IBacteriumService
{
    private readonly IRepository<Bacterium> _repository;

    public BacteriumService(IRepository<Bacterium> repository)
    {
        _repository = repository;
    }

    public void AddNew(string name) => _repository.Add(new Bacterium { Name = name });

    public List<string> GetNamesAllBacterium() => _repository.GetAll().Select(b => b.Name).ToList();
    public Bacterium GetById(int id) => _repository.GetById(id);

    public Bacterium GetByName(string name) => _repository.GetAll().FirstOrDefault(b => b.Name == name);
}