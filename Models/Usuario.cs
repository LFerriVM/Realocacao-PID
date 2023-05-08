using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class Usuario
{
    [Key]
    public int IdUsuario { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Senha { get; set; }

    [NotMapped]
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    [Compare("Senha", ErrorMessage = "O campo {0} deve ser igual ao campo {1}.")]
    public string ConfSenha { get; set; }
}