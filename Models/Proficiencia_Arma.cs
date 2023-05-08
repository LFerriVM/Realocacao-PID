using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Proficiencia_Arma{
    
    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }
    
    [ForeignKey("Arma")]
    public int IdArma { get; set; }
    public Arma Arma { get; set; }
    public void SetProficiencia(int IdP, int IdA){
        this.IdPersonagem = IdP;
        this.IdArma = IdA;
    }
    public void SetProficienciaTipo(int Idp, int IdT){
        if(IdT == 1)
        {
            for(int i = 1; i<=10; i++){
                this.IdArma = i;
                this.IdPersonagem = Idp;
            }
        }
        else if(IdT == 2)
        {
            for(int i = 11; i<=14; i++){
                this.IdArma = i;
                this.IdPersonagem = Idp;
            }
        }
        else if(IdT == 3)
        {
            for(int i = 15; i<=31; i++){
                this.IdArma = i;
                this.IdPersonagem = Idp;
            }
        }
        else if(IdT == 4)
        {
            for(int i = 32; i<=36; i++){
                this.IdArma = i;
                this.IdPersonagem = Idp;
            }
        }
    }
}