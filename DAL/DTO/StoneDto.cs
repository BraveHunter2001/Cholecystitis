using DAL.Model.Enum;

namespace DAL.DTO;

public class StoneDto
{
    public StoneType Type { get; set; }
    public string Color { get; set; }
    public string Composition { get; set; }
}
