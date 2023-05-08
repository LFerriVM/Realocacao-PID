using Models;
using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Projeto.Controllers;

public class PericiaController : Controller
{
    private DataContext _db;
    public PericiaController(DataContext db)
    {
        _db = db;
    }
    [HttpGet]
    public ActionResult EscolherPericia(int IdPersonagem)
    {
        ViewBagdeCria();
        var personagem = _db.Personagens.Find(IdPersonagem);

        return View(personagem);
    }
    public void ViewBagdeCria(){
        var listaantecedente = _db.Antecedentes.AsNoTracking().ToList();
        var listaclasse = _db.Classes.AsNoTracking().ToList();
        ViewBag.listaantecedente = listaantecedente;
        ViewBag.listaclasse = listaclasse;
    }
    [HttpPost]
    public IActionResult EscolherPericia(int IdPersonagem, Personagem personagem)
    {
        var varoriginal = _db.Personagens.Find(IdPersonagem);
        
        varoriginal.Acrobacia = personagem.Acrobacia;
        varoriginal.Arcanismo = personagem.Arcanismo;
        varoriginal.Atletismo = personagem.Atletismo;
        varoriginal.Atuacao = personagem.Atuacao;
        varoriginal.Enganacao = personagem.Enganacao;
        varoriginal.Furtividade = personagem.Furtividade;
        varoriginal.Historia = personagem.Historia;
        varoriginal.Intimidacao = personagem.Intimidacao;
        varoriginal.Intuicao = personagem.Intuicao;
        varoriginal.Investigacao = personagem.Investigacao;
        varoriginal.LidarcomAnimais = personagem.LidarcomAnimais;
        varoriginal.Medicina = personagem.Medicina;
        varoriginal.Natureza = personagem.Natureza;
        varoriginal.Percepcao = personagem.Percepcao;
        varoriginal.Persuasao = personagem.Persuasao;
        varoriginal.Prestidigitacao = personagem.Prestidigitacao;
        varoriginal.Religiao = personagem.Religiao;
        varoriginal.Sobrevivencia = personagem.Sobrevivencia;

        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }
}