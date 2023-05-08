using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class TipoArma
{
    [Key]
    public int IdTipoArma { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Tipo { get; set; }

}