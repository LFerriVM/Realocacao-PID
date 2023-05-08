using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class TipoMagia
{
    [Key]
    public int IdTipoMagia { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Tipo { get; set; }
}