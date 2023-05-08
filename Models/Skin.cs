using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Skin
{
    [Key]
    public int IdSkin { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public double? Valor { get; set; }
    
    [ForeignKey("Designer")]
    public int IdDesigner { get; set; }
    public Designer Designer { get; set; }
}