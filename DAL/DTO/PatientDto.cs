using DAL.Model.Enum;

namespace DAL.DTO;

public class PatientDto
{
    public string Name { get; set; }
    public int Age { get; set; }
    public Gender Gender { get; set; }
    public string RiskFactors { get; set; }
}
