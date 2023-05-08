using System.ComponentModel.DataAnnotations;

namespace Models;
public class Talento{
    [Key]
    public int IdTalento { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public string Prerequisitos { get; set; }
}