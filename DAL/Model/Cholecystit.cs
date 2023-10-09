using DAL.Model.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.Model;

public class Cholecystit
{
    public Guid Id { get; set; }
    public Degree Degree { get; set; }
    public CholecystitType Type { get; set; }
    public string Symptoms { get; set; }
    public string Pathophysiology { get; set; }
    public string Histology { get; set; }
    public string CausedComplications { get; set; }
    public string Treatment { get; set; }

    public Patient Patient { get; set; }
    public List<Stone> Stones { get; set; }
    public List<Bacterium> Bacterias { get; set; }


    [NotMapped]
    public bool HasBacterialInfection => Bacterias?.Any() ?? false;

}