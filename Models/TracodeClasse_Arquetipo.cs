using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class TracodeClasse_Arquetipo
{
    [ForeignKey("TracodeClasse")]
    public int IdTracodeClasse { get; set; }
    public TracodeClasse TracodeClasse { get; set; }

    [ForeignKey("Arquetipo")]
    public int IdArquetipo { get; set; }
    public Arquetipo Arquetipo { get; set; }
}