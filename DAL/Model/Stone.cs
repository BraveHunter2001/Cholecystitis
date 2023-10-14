using DAL.Model.Enum;

namespace DAL.Model;

public class Stone
{
    public Guid Id { get; set; }
    public StoneType Type { get; set; }
    public string Color { get; set; }
    public string Composition { get; set; }

    public Guid? CholecystitId { get; set; }
    public Cholecystit Cholecystit { get; set; }
}