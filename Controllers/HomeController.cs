using System.Diagnostics;
using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projeto.Controllers;

public class HomeController : Controller
{
    private DataContext _db;
    public HomeController(DataContext db){
        _db = db;
    }

    //Tela Principal
    public IActionResult Index()
    {
        return View();
    }

    //Exibir Fichas
    [Authorize]
    [HttpGet]
    public IActionResult ExibirFicha()
    {   
        ViewBagdeCria();
        var personagem = _db.Personagens.Include(c => c.Classe).Include(r => r.Raca).Include(sr => sr.SubRaca).Include(u=>u.Usuario).AsNoTracking().ToList();
        return View(personagem);
    }

    public void ViewBagdeCria(){
        var listaraca = _db.Racas.AsNoTracking().ToList();
        var listausuario = _db.Usuarios.AsNoTracking().ToList();
        var listasubraca = _db.SubRacas.AsNoTracking().ToList();
        ViewBag.Listaraca = listaraca;
        ViewBag.listausuario = listausuario;
        ViewBag.listasubraca = listasubraca;
        var usuario = _db.Usuarios.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
        ViewBag.usuariologado = usuario;
        var listaclasse = _db.Classes.AsNoTracking().ToList();
        ViewBag.listaclasse = listaclasse;
    }

    //Excluir Personagem
    [HttpGet]
    public ActionResult ExcluirFicha(int IdPersonagem){
        var var = _db.Personagens.Find(IdPersonagem);
        if (var is null)
            return RedirectToAction("Index");

        return View(var);
    }
    [HttpPost]
    public ActionResult ProcessarExcluir(int IdPersonagem){
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        if (personagemoriginal is null){
            return RedirectToAction("Index");
        }
        _db.Personagens.Remove(personagemoriginal);
        _db.SaveChanges();
        return RedirectToAction("ExibirFicha");
    }
}
