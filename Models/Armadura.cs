using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Armadura
{
    [Key]
    public int IdArmadura { get; set; }

    public int ClassedeArmadura { get; set; }
    public int? ModificadorDestrezaMaximo { get; set; }
    public int? Forca { get; set; }
    public bool? Furtividade { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Peso { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Preco { get; set; }

    [ForeignKey("TipoArmadura")]
    public int IdTipoArmadura { get; set; }
    public TipoArmadura TipoArmadura { get; set; }

    [NotMapped]
    public ICollection<Personagem_Armadura> Personagens_Armaduras { get; set; }
}