using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class SubRaca
{
    [Key]
    public int IdSubRaca { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    public int? BonusConstituicao { get; set; }
    public int? BonusForca { get; set; }
    public int? BonusDestreza { get; set; }
    public int? BonusInteligencia { get; set; }
    public int? BonusSabedoria { get; set; }
    public int? BonusCarisma { get; set; }
    // public List<int> ProfArma { get; set; }
    // public List<int> ProfArmadura { get; set; }
    // public List<int> ProfItem { get; set; }

    [ForeignKey("Raca")]
    public int IdRaca { get; set; }
    public Raca Raca { get; set; }
[NotMapped]
    public ICollection<HabilidadeRacial_SubRaca> HabilidadesRaciais_SubRacas { get; set; }

}