using System.ComponentModel.DataAnnotations;

namespace Models;

public class LoginViewModel{

    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "O campo {0} é de preenchimento obrigatório.")]
    public string Senha { get; set; }
    public bool Lembrar { get; set; }
}