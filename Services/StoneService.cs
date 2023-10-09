using DAL.Model;
using DAL.Model.Enum;
using DAL.Repositories;
using System.Drawing;

namespace Services;

public interface IStoneService
{
    public Stone Add(StoneType stoneType, string color, string composition);
    public void Remove(Guid id);
    public Stone GetStone(Guid id);
}

public class StoneService : IStoneService
{
    private readonly IRepository<Stone> _stoneRepository;

    public StoneService(IRepository<Stone> stoneRepository)
    {
        _stoneRepository = stoneRepository;
    }

    public Stone Add(StoneType stoneType, string color, string composition)
    {
        var id = Guid.NewGuid();
        var stone = new Stone { Id = id, Type = stoneType, Color = color, Сomposition = composition};
        _stoneRepository.Add(stone);

        return stone;
    }

    public void Remove(Guid id)
    {
        _stoneRepository.Delete(id);
    }

    public Stone GetStone(Guid id) => _stoneRepository.GetById(id);
}