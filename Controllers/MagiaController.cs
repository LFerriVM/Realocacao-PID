using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projeto.Controllers;

public class MagiaController : Controller
{
    private DataContext _db;
    public MagiaController(DataContext db){
        _db = db;
    }
    public ActionResult Escolher()
    {
        return View();
    }
    [HttpGet]
    public IActionResult InserirMagia(){
        var lista = _db.Magias.AsNoTracking().OrderBy(a => a.IdMagia).ToList();
        var Select = new SelectList(lista, "IdMagia", "Nome");
        ViewBag.Select = Select;
        var var = new Magia();
        return View(var);
    }
    [HttpPost]
    public IActionResult InserirMagia(Magia var){
        
        if(!ModelState.IsValid){
            return View(var);
        }
        _db.Magias.Add(var);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}