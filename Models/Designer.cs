using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Designer
{

    [Key]
    public int IdDesigner { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    [StringLength(60, ErrorMessage = "Insira, no máximo, 60 caracteres")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    [StringLength(11, ErrorMessage = "Você excedeu o limite máximo de caracteres. Certifique-se de que está inserindo apenas os nove digitos, do número e o DDD -desconsiderando, se houve, o zero a esquerda deste.")]
    public string Telefone { get; set; }
    [Required(ErrorMessage = "Campo Obrigatório")]
    public string Email { get; set; }

}