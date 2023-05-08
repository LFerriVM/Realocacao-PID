using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class HabilidadeRacial_SubRaca
{
    [ForeignKey("HabilidadeRacial")]
    public int IdHabilidadeRacial { get; set; }
    public HabilidadeRacial HabilidadeRacial { get; set; }

    [ForeignKey("SubRaca")]
    public int IdSubRaca { get; set; }
    public SubRaca SubRaca { get; set; }

}