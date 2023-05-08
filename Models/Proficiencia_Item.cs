using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Proficiencia_Item{

    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }

    [ForeignKey("Item")]
    public int IdItem { get; set; }
    public Item Item { get; set; }

    public void SetProficiencia(int IdP, int IdI){
        this.IdPersonagem = IdP;
        this.IdItem = IdI;
    }
}