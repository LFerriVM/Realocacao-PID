using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Projeto.Controllers;

public class DesignerController : Controller
{
    private DataContext _db;
    public DesignerController(DataContext db){
        _db = db;
    }
    public ActionResult Exibir()
    {
        return View();
    }
    // [HttpGet]
    // public IActionResult Designer(){
    //     var designer = new Designer();
    //     return View(designer);
    // }
    // [HttpPost]
    // public IActionResult Designer(Designer designer){
        
    //     if(!ModelState.IsValid){
    //         return View(designer);
    //     }
    //     _db.Designer.Add(designer);
    //     _db.SaveChanges();
    //     return RedirectToAction("Index", "Home");
    // }
}