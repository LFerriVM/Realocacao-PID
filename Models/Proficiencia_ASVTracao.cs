using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Proficiencia_ASVTracao{
    
    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }

    [ForeignKey("ASVTracao")]
    public int IdASVTracao { get; set; }
    public ASVTracao ASVTracao { get; set; }

    public void SetProficiencia(int IdP, int IdASVTRacao){
        this.IdPersonagem = IdP;
        this.IdASVTracao = IdASVTRacao;
    }
    
    
}