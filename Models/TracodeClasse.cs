using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class TracodeClasse
{
    [Key]
    public int IdTracodeClasse { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string HabilidadeTracodeClasse { get; set; }

    [NotMapped]
    public ICollection<Classe_TracodeClasse> Classes_TracosdeClasses { get; set; }
    [NotMapped]
    public ICollection<TracodeClasse_Arquetipo> TracosdeClasse_Arquetipos { get; set; }

}