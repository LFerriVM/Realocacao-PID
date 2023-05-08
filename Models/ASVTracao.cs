using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class ASVTracao{
    [Key]
    public int IdASVTracao { get; set; }
    public string Nome { get; set; }
    public string Preco { get; set; }
    public string Peso { get; set; }
}