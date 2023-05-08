using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Arma{
    [Key]
    public int IdArma { get; set; }
    public string DadoDano { get; set; }
    public string Propriedade { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Peso { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Preco { get; set; }

    [ForeignKey("TipoArma")]
    public int IdTipoArma { get; set; }
    public TipoArma TipoArma { get; set; }

    [NotMapped]
    public ICollection<Personagem_Arma> Personagens_Armas { get; set; }
}