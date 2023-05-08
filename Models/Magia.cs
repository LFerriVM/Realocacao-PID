using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Magia
{
    [Key]
    public int IdMagia { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Escola { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Alcance { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string TempodeConjuracao { get; set; }
    [Required]
    public string Duracao { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Componente { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Descricao { get; set; }

    [ForeignKey("TipoMagia")]
    public int IdTipoMagia { get; set; }
    public TipoMagia TipoMagia { get; set; }

}