using Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;

namespace Projeto.Controllers;

public class AntecedenteController : Controller
{
    private DataContext _db;
    public AntecedenteController(DataContext db)
    {
        _db = db;
    }
    [HttpGet]
    public ActionResult EscolherAntecedente(int IdPersonagem)
    {
        ViewBagdeCria();
        var personagem = _db.Personagens.Find(IdPersonagem);
        return View(personagem);
    }
    private void ViewBagdeCria()
    {
        var listaantecedente = _db.Antecedentes.AsNoTracking().OrderBy(a => a.IdAntecedente).ToList();
        var listaidioma = _db.Idiomas.Include(b => b.TipoIdioma).AsNoTracking().OrderBy(a => a.IdIdioma).ToList();
        var listaitem = _db.Itens.AsNoTracking().OrderBy(a => a.IdItem).ToList();
        var listaarma = _db.Armas.AsNoTracking().OrderBy(a => a.IdArma).ToList();
        var listaarmadura = _db.Armaduras.AsNoTracking().OrderBy(a => a.IdArmadura).ToList();
        var listaveiculoterrestre = _db.VeiculosTerrestres.AsNoTracking().ToList();
        var listaveiculoaquatico = _db.VeiculosAquaticos.AsNoTracking().ToList();
        ViewBag.listaantecedente = listaantecedente;
        ViewBag.listaidioma = listaidioma;
        ViewBag.listaitem = listaitem;
        ViewBag.listaarma = listaarma;
        ViewBag.listaarmadura = listaarmadura;
        ViewBag.listaveiculoterrestre = listaveiculoterrestre;
        ViewBag.listaveiculoaquatico = listaveiculoaquatico;
    }
    [HttpPost]
    public IActionResult EscolherAntecedente(Personagem personagem, int IdPersonagem, List<int> armas, List<int> armaduras, List<int> itens, List<int> profarmas, List<int> profarmaduras, List<int> profitens, List<int> profveicter, List<int> profveicaq, List<int> idiomaspersonagem)
    {
        
        var varoriginal = _db.Personagens.Find(IdPersonagem);
        if(personagem.IdAntecedente == 1)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 15, 0);
            itens.AddRange(new int[]{85, 82, 5, 54});

            varoriginal.Intuicao = true;
            varoriginal.Religiao = true;            
        }
        else if(personagem.IdAntecedente == 2)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 15, 0);
            itens.AddRange(new int[]{83, 5});
            varoriginal.Intuicao = true;
            varoriginal.Persuasao = true;
        }
        else if(personagem.IdAntecedente == 3)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 15, 0);
            itens.AddRange(new int[]{85, 5});
            profitens.Add(128);
            varoriginal.Acrobacia = true;
            varoriginal.Atuacao = true;
        }
        else if(personagem.IdAntecedente == 4)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 15, 0);
            itens.AddRange(new int[]{128, 5});
            profitens.AddRange(new int[]{128, 129});
            varoriginal.Enganacao = true;
            varoriginal.Prestidigitacao = true;
        }
        else if(personagem.IdAntecedente == 5)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 15, 0);
            itens.AddRange(new int[]{82, 5, 69});
            profitens.Add(117);
            varoriginal.Enganacao = true;
            varoriginal.Furtividade = true;
        }
        else if(personagem.IdAntecedente == 6)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 5, 0);
            itens.AddRange(new int[]{5, 72, 23, 82, 130});
            profitens.Add(130);
            varoriginal.Medicina = true;
            varoriginal.Religiao = true;

        }
        else if(personagem.IdAntecedente == 7)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 10, 0);
            armas.Add(3);
            itens.AddRange(new int[]{5, 11, 83});
            varoriginal.Atletismo = true;
            varoriginal.Sobrevivencia = true;
        }
        else if(personagem.IdAntecedente == 8)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 10, 0);
            itens.AddRange(new int[]{5, 65, 66, 82});
            varoriginal.LidarcomAnimais = true;
            varoriginal.Sobrevivencia = true;
        }
        else if(personagem.IdAntecedente == 9)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 10, 0);
            armas.Add(4);
            itens.AddRange(new int[]{5, 25, 89, 82});
            varoriginal.Atletismo = true;
            varoriginal.Percepcao = true;
        }
        else if(personagem.IdAntecedente == 10)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 25, 0);
            itens.AddRange(new int[]{5, 85, 72});
            varoriginal.Historia = true;
            varoriginal.Persuasao = true;
        }
        else if(personagem.IdAntecedente == 11)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 10, 0);
            itens.AddRange(new int[]{82, 5});
            profitens.AddRange(new int[]{117, 128});
            varoriginal.Furtividade = true;
            varoriginal.Prestidigitacao = true;
        }
        else if(personagem.IdAntecedente == 12)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 10, 0);
            itens.AddRange(new int[]{5, 82, 96, 67});
            varoriginal.Historia = true;
            varoriginal.Arcanismo = true;
        }
        else if(personagem.IdAntecedente == 13)
        {
            varoriginal.AumentarDinheiro(0, 0, 0, 10, 0);
            itens.AddRange(new int[]{132, 82, 5});
            varoriginal.Atletismo = true;
            varoriginal.Intimidacao = true;
        }

        if (varoriginal is null)
        {
            return RedirectToAction("Index");
        }

        if (personagem.IdAntecedente is null)
        {
            ViewBagdeCria();
            return View(personagem);
        }
        foreach (var arma in armas)
        {
            if(_db.Personagens_Armas.Find(IdPersonagem, arma) is null)
            {
                var personagem_arma = new Personagem_Arma();
                personagem_arma.SetPersonagem_Arma(IdPersonagem, arma);
                _db.Personagens_Armas.Add(personagem_arma);
            }
            else
            {
                var personagem_arma = _db.Personagens_Armas.Find(IdPersonagem, arma);
                personagem_arma.Qtd++;
                _db.SaveChanges();
            }
        }
        foreach (var armadura in armaduras)
        {
            if(_db.Personagens_Armaduras.Find(IdPersonagem, armadura) is null)
            {
                var personagem_armadura = new Personagem_Armadura();
                personagem_armadura.SetPersonagem_Armadura(IdPersonagem, armadura);
                _db.Personagens_Armaduras.Add(personagem_armadura);
            }
            else
            {
                var personagem_armadura = _db.Personagens_Armaduras.Find(IdPersonagem, armadura);
                personagem_armadura.Qtd++;
                _db.SaveChanges();
            }
        }
        foreach (var item in itens)
            {
                if(_db.Personagens_Itens.Find(IdPersonagem, item) is null)
                {
                    var personagem_item = new Personagem_Item();
                    personagem_item.SetPersonagem_Item(IdPersonagem, item);
                    _db.Personagens_Itens.Add(personagem_item);
                }
                else
            {
                var personagem_item = _db.Personagens_Itens.Find(IdPersonagem, item);
                personagem_item.Qtd++;
                _db.SaveChanges();
            }
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
        foreach (var veiter in profveicter)
        {
            if(_db.Proficiencias_VeiculosTerrestres.Find(IdPersonagem, veiter) is null)
            {
                var proficiencia_veiculoterrestre = new Proficiencia_VeiculoTerrestre();
                proficiencia_veiculoterrestre.SetProficiencia(IdPersonagem, veiter);
                _db.Proficiencias_VeiculosTerrestres.Add(proficiencia_veiculoterrestre);
            }
        }
        foreach (var veiaq in profveicaq)
        {
            if(_db.Proficiencias_VeiculosAquaticos.Find(IdPersonagem, veiaq) is null)
            {
                var proficiencia_veiculoaquatico = new Proficiencia_VeiculoAquatico();
                proficiencia_veiculoaquatico.SetProficiencia(IdPersonagem, veiaq);
                _db.Proficiencias_VeiculosAquaticos.Add(proficiencia_veiculoaquatico);
            }
        }
        foreach (var idioma in idiomaspersonagem)
        {
            if(_db.Idiomas_Personagens.Find(idioma, IdPersonagem) is null)
            {
                var idioma_personagem = new Idioma_Personagem();
                idioma_personagem.DefinirIdioma(idioma, IdPersonagem);
                _db.Idiomas_Personagens.Add(idioma_personagem);
            }
        }

        varoriginal.IdAntecedente = personagem.IdAntecedente;
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new{personagem.IdPersonagem});
    }

    // private void NewMethod()
    // {
    //     var lista = _db.Antecedentes.Include(i => Idioma).AsNoTracking().OrderBy(a => a.IdAntecedente).ToList();
    //     var Select = new SelectList(lista, "IdAntecedente", "Nome");
    //     ViewBag.Select = Select;
    // }

}