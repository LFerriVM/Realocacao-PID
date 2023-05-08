using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Projeto.Controllers;

public class AtributoController : Controller
{
    private DataContext _db;
    public AtributoController(DataContext db)
    {
        _db = db;
    }
    [HttpGet]
    public ActionResult EscolherAtributo(int IdPersonagem)
    {
        var personagem = _db.Personagens.Find(IdPersonagem);
        return View(personagem);
    }

    [HttpPost]
    public ActionResult EscolherAtributo(Personagem personagem, int IdPersonagem)
    {

        var varoriginal = _db.Personagens.Find(IdPersonagem);
        if (varoriginal is null)
        {
            return RedirectToAction("Index", "Home");
        }
    	if(varoriginal == personagem)
        {
            return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
        }
        varoriginal.Forca = personagem.Forca;
        varoriginal.Destreza = personagem.Destreza;
        varoriginal.Constituicao = personagem.Constituicao;
        varoriginal.Inteligencia = personagem.Inteligencia;
        varoriginal.Sabedoria = personagem.Sabedoria;
        varoriginal.Carisma = personagem.Carisma;
        varoriginal.DefinirModificadores();
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }
}