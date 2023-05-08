using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Personagem_VeiculoAquatico
{
    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }

    [ForeignKey("VeiculoAquatico")]
    public int IdVeiculoAquatico { get; set; }
    public VeiculoAquatico VeiculoAquatico { get; set; }
    

    public void SetPersonagem_VeiculoAquatico(int ida, int idp){
        this.IdVeiculoAquatico = ida;
        this.IdPersonagem = idp;
    }

}