using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class HabilidadeRacial_Raca
{
    [ForeignKey("HabilidadeRacial")]
    public int IdHabilidadeRacial { get; set; }
    public HabilidadeRacial HabilidadeRacial { get; set; }

    [ForeignKey("Raca")]
    public int IdRaca { get; set; }
    public Raca Raca { get; set; }

}