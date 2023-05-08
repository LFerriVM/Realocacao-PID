using Microsoft.AspNetCore.Mvc;
using Models;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto.Controllers;

public class HabilidadeController : Controller
{
    private readonly DataContext _db;
    public HabilidadeController(DataContext db){
        _db = db;
    }

    public ActionResult Escolher()
    {
        return View();
    }
    [HttpGet]
    public IActionResult InserirHabilidadeRacial(){
        var lista = _db.HabilidadesRaciais.AsNoTracking().OrderBy(a => a.IdHabilidadeRacial).ToList();
        var Select = new SelectList(lista, "IdHabilidadeRacial", "Nome");
        ViewBag.Select = Select;
        var var = new HabilidadeRacial();
        return View(var);
    }
    [HttpPost]
    public IActionResult InserirHabilidadeRacial(HabilidadeRacial var){
        
        if(!ModelState.IsValid){
            return View(var);
        }
        _db.HabilidadesRaciais.Add(var);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}