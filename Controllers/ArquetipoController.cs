using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projeto.Controllers;

public class ArquetipoController : Controller
{
    private DataContext _db;
    public ArquetipoController(DataContext db){
        _db = db;
    }
    public ActionResult Escolher()
    {
        return View();
    }
    [HttpGet]
    public IActionResult InserirArquetipo(){
        var lista = _db.Arquetipos.AsNoTracking().OrderBy(a => a.IdArquetipo).ToList();
        var Select = new SelectList(lista, "IdArquetipo", "Nome");
        ViewBag.Select = Select;
        var var = new Arquetipo();
        return View(var);
    }
    [HttpPost]
    public IActionResult InserirArquetipo(Arquetipo var){
        
        if(!ModelState.IsValid){
            return View(var);
        }
        _db.Arquetipos.Add(var);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
}