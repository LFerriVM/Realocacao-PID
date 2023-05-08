using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Arquetipo
{
    [Key]
    public int IdArquetipo { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string HabilidadeArquetipo { get; set; }

    [NotMapped]
    public ICollection<TracodeClasse_Arquetipo> TracosdeClasse_Arquetipos { get; set; }
}