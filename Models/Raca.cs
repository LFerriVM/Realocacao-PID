using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Raca
{
    [Key]
    public int IdRaca { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Tamanho { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public int Idade { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public double Deslocamento { get; set; }
    public int? BonusConstituicao { get; set; }
    public int? BonusForca { get; set; }
    public int? BonusDestreza { get; set; }
    public int? BonusInteligencia { get; set; }
    public int? BonusSabedoria { get; set; }
    public int? BonusCarisma { get; set; }
    // public List<int> ProfArma { get; set; }
    // public List<int> ProfArmadura { get; set; }
    // public List<int> ProfItem { get; set; }


    [ForeignKey("Idioma")]
    public int IdIdioma { get; set; }
    public Idioma Idioma { get; set; }

[NotMapped]
    public ICollection<HabilidadeRacial_Raca> HabilidadesRaciais_Racas { get; set; }
}