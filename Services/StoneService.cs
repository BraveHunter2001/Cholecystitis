using DAL.DTO;
using DAL.Model;
using DAL.Model.Enum;
using DAL.Repositories;
using System.Drawing;

namespace Services;

public interface IStoneService
{
    public Stone Add(StoneType stoneType, string color, string composition);
    public Stone Add(StoneType stoneType, string color, string composition, Guid cholecystitId);
    public Stone Add(StoneDto stoneDto, Guid cholecystitId);
    public List<Stone> Add(StoneDto[] stonesDto, Guid cholecystitId);
    public void Remove(Guid id);
    public Stone GetStone(Guid id);
    public Stone Update(Stone stone);
    public List<Stone> Update(List<Stone> stones);
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
        var stone = new Stone { Id = id, Type = stoneType, Color = color, Composition = composition };
        _stoneRepository.Add(stone);

        return stone;
    }

    public Stone Add(StoneType stoneType, string color, string composition, Guid cholecystitId)
    {
        var id = Guid.NewGuid();
        var stone = new Stone { Id = id, Type = stoneType, Color = color, Composition = composition, CholecystitId = cholecystitId };
        _stoneRepository.Add(stone);

        return stone;
    }

    public Stone Add(StoneDto stoneDto, Guid cholecystitId) => Add(stoneDto.Type, stoneDto.Color, stoneDto.Composition, cholecystitId);

    public List<Stone> Add(StoneDto[] stonesDto, Guid cholecystitId)
    {
        var res = new List<Stone>();
        foreach (var stone in stonesDto)
        {
            res.Add(Add(stone, cholecystitId));
        }

        return res;
    }

    public void Remove(Guid id)
    {
        _stoneRepository.Delete(id);
    }

    public Stone GetStone(Guid id) => _stoneRepository.GetById(id);

    public Stone Update(Stone stone)
        => _stoneRepository.Update(stone);

    public List<Stone> Update(List<Stone> stones)
    {
        var res = new List<Stone>();
        foreach (var stone in stones) res.Add(Update(stone));

        return res;
    }
}