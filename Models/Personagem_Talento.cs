using System.ComponentModel.DataAnnotations.Schema;

namespace Models;
public class Personagem_Talento{
    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }

    [ForeignKey("Talento")]
    public int IdTalento { get; set; }
    public Talento Talento { get; set; }
}