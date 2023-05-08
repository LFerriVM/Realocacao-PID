using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Classe
{
    [Key]
    public int IdClasse { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public int DadoVida { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    public string Equipamento { get; set; }
    public string Proficiencia { get; set; }
    // public List<int> ProfArma { get; set; }
    // public List<int> ProfArmadura { get; set; }
    // public List<int> ProfItem { get; set; }


    [ForeignKey("ListaMagia")]
    public int? IdListaMagia { get; set; }
    public ListaMagia ListaMagia { get; set; }
    [NotMapped]
    public ICollection<Classe_TracodeClasse> Classes_TracosdeClasses { get; set; }

}