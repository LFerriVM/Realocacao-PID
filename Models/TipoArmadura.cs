using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class TipoArmadura
{
    [Key]
    public int IdTipoArmadura { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Tipo { get; set; }

    public ICollection<Armadura> Armaduras { get; set; }

}