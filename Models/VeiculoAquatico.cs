using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class VeiculoAquatico{
    [Key]
    public int IdVeiculoAquatico { get; set; }
    public string Nome { get; set; }
    public string Preco { get; set; }
    public string Velocidade { get; set; }
}