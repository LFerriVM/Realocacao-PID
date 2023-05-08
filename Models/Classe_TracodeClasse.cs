using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Classe_TracodeClasse{
    [ForeignKey("Classe")]
    public int IdClasse { get; set; }
    public Classe Classe { get; set; }

    [ForeignKey("TracodeClasse")]
    public int IdTracodeClasse { get; set; }
    public TracodeClasse TracodeClasse { get; set; }
    
    public int? Nivel { get; set; }

    
}