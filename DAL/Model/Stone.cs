using DAL.Model.Enum;

namespace DAL.Model;

public class Stone
{
    public int Id { get; set; }
    public StoneType Type { get; set; }
    public string Color { get; set; }
    public string Сomposition { get; set; }

    public Cholecystit Cholecystit { get; set; }
}