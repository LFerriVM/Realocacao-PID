using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Projeto.Controllers;

public class ClasseController : Controller
{
    private DataContext _db;
    public ClasseController(DataContext db)
    {
        _db = db;
    }

    [HttpGet]
    public ActionResult EscolherClase(int IdPersonagem)
    {
        ViewBagdeCria();
        var personagem = _db.Personagens.Find(IdPersonagem);
        return View(personagem);
    }

    private void ViewBagdeCria()
    {
        var listaclasse = _db.Classes.AsNoTracking().ToList();
        var listatraco = _db.TracosdeClasse.AsNoTracking().ToList();
        var listaarquetipo = _db.Arquetipos.AsNoTracking().ToList();
        var listaclassetracosdeclasse = _db.Classes_TracosdeClasses.AsNoTracking().ToList();
        var listatracodeclassearquetipo = _db.TracosdeClasse_Arquetipos.AsNoTracking().ToList();
        var listaproficienciaarma = _db.Proficiencias_Armas.AsNoTracking().ToList();
        ViewBag.listaclasse = listaclasse;
        ViewBag.listatraco = listatraco;
        ViewBag.listaarquetipo = listaarquetipo;
        ViewBag.listaclassetracosdeclasse = listaclassetracosdeclasse;
        ViewBag.listatracodeclassearquetipo = listatracodeclassearquetipo;
        ViewBag.listaproficienciaarma = listaproficienciaarma;
    }

    [HttpPost]
    public ActionResult EscolherClasse(int IdPersonagem, Personagem personagem)
    {
        List<int> profarmas = new List<int>();
        List<int> profarmaduras = new List<int>();
        List<int> profarmastipos = new List<int>();
        List<int> profarmadurastipos = new List<int>();
        List<int> profitens = new List<int>();

        var varoriginal = _db.Personagens.Find(IdPersonagem);

        if (personagem.IdClasse == 1)
        {
            for(int i = 1; i<=13; i++)
            {
                if(i < 9 || i > 12){
                    profarmaduras.Add(i);
                }
            }
            for(int i = 1; i<=36; i++)
            {
                profarmas.Add(i);
            }
            personagem.ForcaBool = true;
            personagem.ConstituicaoBool = true;
        }
        else if (personagem.IdClasse == 2)
        {
            for(int i = 1; i <= 14; i++)
            {
                profarmas.Add(i);
            }
            profarmas.AddRange(new int[] { 33, 20, 18, 30 });
            personagem.DestrezaBool = true;
            personagem.CarismaBool = true;
        }
        else if (personagem.IdClasse == 3)
        {
            for(int i = 1; i<=3; i++)
            {
                profarmaduras.Add(i);
            }
            for(int i = 1; i<=14; i++)
            {
                profarmas.Add(i);
            }
            personagem.SabedoriaBool = true;
            personagem.CarismaBool = true;
        }
        else if (personagem.IdClasse == 4)
        {
            for(int i = 1; i<=13; i++)
            {
                if(i < 9 || i > 12){
                    profarmaduras.Add(i);
                }
            }
            for(int i = 1; i<=14; i++)
            {
                profarmas.Add(i);
            }
            personagem.SabedoriaBool = true;
            personagem.CarismaBool = true;
        }
        else if (personagem.IdClasse == 5)
        {
            for(int i = 1; i<=13; i++)
            {
                if(i < 9 || i > 12){
                    profarmaduras.Add(i);
                }
            }
            profarmas.AddRange(new int[] { 1, 2, 3, 4, 5, 6, 7, 13, 14, 16 });
            profitens.Add(130);
            personagem.InteligenciaBool = true;
            personagem.SabedoriaBool = true;
        }
        else if (personagem.IdClasse == 6)
        {
            profarmas.AddRange(new int[] { 1, 3, 12, 13, 14 });
            personagem.ConstituicaoBool = true;
            personagem.CarismaBool = true;
        }
        else if (personagem.IdClasse == 7)
        {
            for(int i = 1; i<=13; i++)
            {
                profarmaduras.Add(i);
            }
            for(int i = 1; i<=36; i++)
            {
                profarmas.Add(i);
            }
            personagem.ForcaBool = true;
            personagem.ConstituicaoBool = true;
        }
        else if (personagem.IdClasse == 8)
        {
            for(int i = 1; i<=3; i++)
            {
                profarmaduras.Add(i);
            }
            for(int i = 1; i<=14; i++)
            {
                profarmas.Add(i);
            }
            profarmas.AddRange(new int[] { 18, 20, 30, 33 });
            personagem.DestrezaBool = true;
            personagem.InteligenciaBool = true;
        }
        else if (personagem.IdClasse == 9)
        {
            profarmas.AddRange(new int[] { 1, 3, 12, 13, 14 });
            personagem.InteligenciaBool = true;
            personagem.SabedoriaBool = true;
        }
        else if (personagem.IdClasse == 10)
        {
            for(int i = 1; i<=10; i++)
            {
                profarmas.Add(i);
            }
            profarmas.Add(18);
            personagem.ForcaBool = true;
            personagem.DestrezaBool = true;
        }
        else if (personagem.IdClasse == 11)
        {
            for(int i = 1; i<=13; i++)
            {
                if(i < 9 || i > 12){
                    profarmaduras.Add(i);
                }
            }
            for(int i = 1; i<=36; i++)
            {
                profarmas.Add(i);
            }
            personagem.SabedoriaBool = true;
            personagem.CarismaBool = true;
        }
        else if (personagem.IdClasse == 12)
        {
            for(int i = 1; i<=13; i++)
            {
                if(i < 9 || i > 12){
                    profarmaduras.Add(i);
                }
            }
            for(int i = 1; i<=36; i++)
            {
                profarmas.Add(i);
            }
            personagem.ForcaBool = true;
            personagem.DestrezaBool = true;
        }

        if (varoriginal is null)
        {
            return RedirectToAction("Index", "Home");
        }
        if (personagem.IdClasse is null)
        {
            ViewBagdeCria();
            return View(personagem);
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

        varoriginal.IdClasse = personagem.IdClasse;
        varoriginal.DefinirBonusdeProficiencia();
        varoriginal.DefinirDinheiro(personagem.IdClasse);
        varoriginal.DefinirSalvaguarda(personagem.ForcaBool, personagem.DestrezaBool, personagem.ConstituicaoBool, personagem.InteligenciaBool, personagem.SabedoriaBool, personagem.CarismaBool);
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }
}