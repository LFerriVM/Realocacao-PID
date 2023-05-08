using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Models;
public class Magia_ListaMagia
{
    [ForeignKey("Magia")]
    public int IdMagia { get; set; }
    public Magia Magia { get; set; }

    [ForeignKey("ListaMagia")]
    public int IdListaMagia { get; set; }
    public ListaMagia ListaMagia { get; set; }

    public int Ciclo { get; set; }
}