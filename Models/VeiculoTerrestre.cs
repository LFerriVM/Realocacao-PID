using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models;

public class VeiculoTerrestre
{
    [Key]
    public int IdVeiculoTerrestre { get; set; }
    public string Nome { get; set; }
    public string Preco { get; set; }
    public string Deslocamento { get; set; }
    public string CapacidadedeCarga { get; set; }
}