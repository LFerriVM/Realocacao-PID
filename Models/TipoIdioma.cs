using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class TipoIdioma
{
    [Key]
    public int IdTipoIdioma { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Tipo { get; set; }
}