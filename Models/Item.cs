using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Item
{
    [Key]
    public int IdItem { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Peso { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Preco { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Descricao { get; set; }

    [NotMapped]
    public ICollection<Personagem_Item> Personagens_itens { get; set; }
}