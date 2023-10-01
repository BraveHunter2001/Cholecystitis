using DAL.Model;
using DAL.Model.Enum;
using DAL.Repositories;
using System.Drawing;

namespace Services;

public interface IStoneService
{
    public void Add(StoneType stoneType, string color, string composition, Cholecystit cholecystit);
    public void Remove(int id);
    public Stone GetStone(int id);
    public void ChangeColor(int id, string color);
    public void ChangeСomposition(int id, string composition);
}

public class StoneService : IStoneService
{
    private readonly IRepository<Stone> _stoneRepository;

    public StoneService(IRepository<Stone> stoneRepository)
    {
        _stoneRepository = stoneRepository;
    }

    public void Add(StoneType stoneType, string color, string composition, Cholecystit cholecystit)
    {
        var stone = new Stone { Type = stoneType, Color = color, Сomposition = composition, Cholecystit = cholecystit };
        _stoneRepository.Add(stone);
    }

    public void Remove(int id)
    {
        _stoneRepository.Delete(id);
    }

    public Stone GetStone(int id) => _stoneRepository.GetById(id);

    public void ChangeColor(int id, string color)
    {
        var stone = _stoneRepository.GetById(id);
        if (stone is null) return;
        stone.Color = color;
        _stoneRepository.Update(stone);
    }

    public void ChangeСomposition(int id, string composition)
    {
        var stone = _stoneRepository.GetById(id);
        if (stone is null) return;
        stone.Сomposition = composition;
        _stoneRepository.Update(stone);
    }
}