using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class HabilidadeRacial
{
    [Key]
    public int IdHabilidadeRacial { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Descricao { get; set; }
[NotMapped]
    public ICollection<HabilidadeRacial_Raca> HabilidadesRaciais_Racas { get; set; }
    [NotMapped]
    public ICollection<HabilidadeRacial_SubRaca> HabilidadesRaciais_SubRacas { get; set; }

}