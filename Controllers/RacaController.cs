using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projeto.Controllers;

public class RacaController : Controller
{
    private DataContext _db;
    public RacaController(DataContext db)
    {
        _db = db;
    }

    [HttpGet]
    public ActionResult EscolherRaca(int IdPersonagem)
    {
        ViewBagdeCria();
        var personagem = _db.Personagens.Find(IdPersonagem);
        if(personagem is null){
            return View(personagem);
        }
        return View(personagem);
    }

    private void ViewBagdeCria()
    {
        var listaraca = _db.Racas.AsNoTracking().ToList();
        var listasubraca = _db.SubRacas.AsNoTracking().ToList();
        var listahabilidade = _db.HabilidadesRaciais.AsNoTracking().ToList();
        var listahabilidaderaca = _db.HabilidadesRaciais_Racas.AsNoTracking().ToList();
        var listahabilidadesubraca = _db.HabilidadesRaciais_SubRacas.AsNoTracking().ToList();
        ViewBag.listaraca = listaraca;
        ViewBag.listasubraca = listasubraca;
        ViewBag.listahabilidade = listahabilidade;
        ViewBag.listahabilidaderaca = listahabilidaderaca;
        ViewBag.listahabilidadesubraca = listahabilidadesubraca;
    }
    [HttpPost]
    public ActionResult EscolherRaca(int IdPersonagem, Personagem personagem)
    {

        List<int> profarmas = new List<int>();
        List<int> profarmaduras = new List<int>();
        List<int> profitens = new List<int>();
        List<int> idiomas = new List<int>();

        if(personagem.IdRaca == 1)
        {
            profarmas.AddRange(new int[]{8, 25, 9, 28});
            idiomas.AddRange(new int[] { 1, 2 });
        }
        else if(personagem.IdRaca == 2)
        {
            idiomas.AddRange(new int[] { 2, 3 });
        }
        else if(personagem.IdRaca == 3)
        {
            idiomas.AddRange(new int[] { 2, 7 });
        }
        else if(personagem.IdRaca == 4)
        {
            idiomas.Add(2);
        }
        else if(personagem.IdRaca == 5)
        {
            idiomas.AddRange(new int[] { 2, 12 });
        }
        else if(personagem.IdRaca == 6)
        {
            idiomas.AddRange(new int[] { 2, 5 });
        }
        else if(personagem.IdRaca == 7)
        {
            idiomas.AddRange(new int[] { 2, 3 });
        }
        else if(personagem.IdRaca == 8)
        {
            idiomas.AddRange(new int[] { 2, 8 });
        }
        else if(personagem.IdRaca == 9)
        {
            idiomas.AddRange(new int[] { 2, 13 });
        }

        if(personagem.IdSubRaca == 2)
        {
            profarmaduras.AddRange(new int[]{1, 2, 3, 4, 5, 6, 7, 8});
        }
        else if(personagem.IdSubRaca == 3)
        {
            profarmas.AddRange(new int[]{18, 20, 11, 32});
        }
        else if(personagem.IdSubRaca == 4)
        {
            profarmas.AddRange(new int[]{18, 20, 11, 32});
        }
        else if(personagem.IdSubRaca == 5)
        {
            profarmas.AddRange(new int[] {30, 18, 33});
        }

        var varoriginal = _db.Personagens.Find(IdPersonagem);
        if (varoriginal is null)
        {
            return RedirectToAction("Index");
        }
       foreach (var profarma in profarmas)
        {
            if(_db.Proficiencias_Armas.Find(IdPersonagem, profarma) is null)
            {
                var proficiencia_arma = new Proficiencia_Arma();
                proficiencia_arma.SetProficiencia(IdPersonagem, profarma);
                _db.Proficiencias_Armas.Add(proficiencia_arma);
            }
        }
        foreach (var profarmadura in profarmaduras)
        {
            if(_db.Proficiencias_Armaduras.Find(IdPersonagem, profarmadura) is null)
            {
                var proficiencia_armadura = new Proficiencia_Armadura();
                proficiencia_armadura.SetProficiencia(IdPersonagem, profarmadura);
                _db.Proficiencias_Armaduras.Add(proficiencia_armadura);
            }
        }
        foreach (var profitem in profitens)
        {
            if(_db.Proficiencias_Itens.Find(IdPersonagem, profitem) is null)
            {
                var proficiencia_item = new Proficiencia_Item();
                proficiencia_item.SetProficiencia(IdPersonagem, profitem);
                _db.Proficiencias_Itens.Add(proficiencia_item);
            }
        }
        foreach(var idioma in idiomas)
        {
            if(_db.Idiomas_Personagens.Find(idioma, IdPersonagem) is null)
            {
                var idioma_personagem = new Idioma_Personagem();
                idioma_personagem.DefinirIdioma(idioma, IdPersonagem);
                _db.Idiomas_Personagens.Add(idioma_personagem);
            }
        }
        varoriginal.IdRaca = personagem.IdRaca;
        varoriginal.IdSubRaca = personagem.IdSubRaca;
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }
}