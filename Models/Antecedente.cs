using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Antecedente
{
    [Key]
    public int IdAntecedente { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Traco { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Ideal { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Vinculo { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Defeito { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Habilidade { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Proficiencia { get; set; }
    public int? IdiomaQtd { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Equipamento { get; set; }
    // public List<int> ProfArma { get; set; }
    // public List<int> ProfArmadura { get; set; }
    // public List<int> ProfItem { get; set; }
}