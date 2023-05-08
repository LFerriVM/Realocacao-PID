using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Personagem_Armadura
{
    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }

    [ForeignKey("Armadura")]
    public int IdArmadura { get; set; }
    public Armadura Armadura { get; set; }

    public int Qtd { get; set; }
    
    public bool? IsEquipada { get; set; }

    public Personagem_Armadura()
    {
        this.Qtd = 1;
        this.IsEquipada = false;
    }


    public void SetPersonagem_Armadura(int IdPersonagem, int IdArmadura)
    {
        this.IdPersonagem = IdPersonagem;
        this.IdArmadura = IdArmadura;

    }
    public void MudarQtdPersonagem_Armadura(int? Qtd = null)
    {
        if (Qtd is null)
        {
            this.Qtd++;
        }
        else if (Qtd == this.Qtd)
        {

        }
        else if (Qtd < this.Qtd)
        {
            this.Qtd = this.Qtd - Math.Abs(Convert.ToInt32(this.Qtd - Qtd));
        }
        else
        {
            this.Qtd = Convert.ToInt32(Qtd);
        }
    }
}