using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Proficiencia_VeiculoTerrestre{
    
    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }

    [ForeignKey("VeiculoTerrestre")]
    public int IdVeiculoTerrestre { get; set; }
    public VeiculoTerrestre VeiculoTerrestre { get; set; }

    public void SetProficiencia(int IdP, int IdVT){
        this.IdPersonagem = IdP;
        this.IdVeiculoTerrestre = IdVT;
    }
}