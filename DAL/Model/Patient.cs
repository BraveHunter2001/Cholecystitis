using DAL.Model.Enum;

namespace DAL.Model;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string RiskFactors {  get; set; }

    public int CholecystitId { get; set; }
    public Cholecystit Cholecystit { get; set; }
}