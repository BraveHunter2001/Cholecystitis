namespace DAL.Model;
public class Bacterium
{
    public Guid Id { get; set; }
    public string Name { get; set; } 
    public List<Cholecystit> Cholecystits { get; set; } 
}
