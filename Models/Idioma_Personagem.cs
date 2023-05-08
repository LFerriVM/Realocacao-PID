using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Idioma_Personagem
{
    [ForeignKey("Idioma")]
    public int IdIdioma { get; set; }
    public Idioma Idioma { get; set; }

    [ForeignKey("Personagem")]
    public int IdPersonagem { get; set; }
    public Personagem Personagem { get; set; }

    public void DefinirIdioma(int IdIdioma, int IdPersonagem)
    {
        this.IdIdioma = IdIdioma;
        this.IdPersonagem = IdPersonagem;
    }
}