using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Idioma
{
    [Key]
    public int IdIdioma { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string FaladoPor { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Alfabeto { get; set; }

    [ForeignKey("TipoIdioma")]
    public int IdTipoIdioma { get; set; }
    public TipoIdioma TipoIdioma { get; set; }

}