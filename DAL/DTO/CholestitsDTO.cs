using DAL.Model.Enum;

namespace DAL.DTO;

public class CholestitsDTO
{
    public Degree Degree { get; set; }
    public CholecystitType Type { get; set; }
    public string Symptoms { get; set; }
    public string Pathophysiology { get; set; }
    public string Histology { get; set; }
    public string CausedComplications { get; set; }
    public string Treatment { get; set; }

    public Guid[] BacteriesID { get; set; }
    public PatientDto Patient { get; set; }
    public StoneDto[] Stones { get; set; }
}