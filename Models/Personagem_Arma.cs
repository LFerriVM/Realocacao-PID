using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Personagem_Arma
{
    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }

    [ForeignKey("Arma")]
    public int IdArma { get; set; }
    public Arma Arma { get; set; }
    public int Qtd { get; set; }
    public bool? IsEquipada { get; set; }
    
    public Personagem_Arma()
    {
        this.Qtd = 1;
        this.IsEquipada = false;
    }
    

    public void SetPersonagem_Arma(int IdPersonagem, int IdArma){
        this.IdPersonagem = IdPersonagem;
        this.IdArma = IdArma;
        
    }

    public void MudarQtdPersonagem_Arma(int? Qtd = null)
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