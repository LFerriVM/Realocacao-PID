using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Personagem_ASVTracao
{
    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }

    [ForeignKey("ASVTracao")]
    public int IdASVTracao { get; set; }
    public ASVTracao ASVTracao { get; set; }

    public void SetPersonagem_ASVTracao(int idasvtracao, int idp){
        this.IdASVTracao = idasvtracao;
        this.IdPersonagem = idp;
    }
}