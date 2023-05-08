using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Personagem_Item
{
    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }

    [ForeignKey("Item")]
    public int IdItem { get; set; }
    public Item Item { get; set; }
    public int Qtd { get; set; }

    public Personagem_Item()
    {
        this.Qtd = 1;
    }


    public void SetPersonagem_Item(int IdPersonagem, int IdItem)
    {
        this.IdPersonagem = IdPersonagem;
        this.IdItem = IdItem;
    }
    public void MudarQtdPersonagem_Item(int? Qtd = null)
    {
        if(Qtd is null)
        {
            this.Qtd++;
        }
        else if(Qtd == this.Qtd)
        {

        }
        else if(Qtd < this.Qtd)
        {
            this.Qtd =  this.Qtd - Math.Abs(Convert.ToInt32(this.Qtd - Qtd));
        }
        else
        {
            this.Qtd = Convert.ToInt32(Qtd);
        }
    }
}