using Microsoft.AspNetCore.Mvc;
using Models;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Projeto.Controllers;

public class ItemController : Controller
{
    private readonly DataContext _db;
    public ItemController(DataContext db)
    {
        _db = db;
    }

    public IActionResult ObterItensPersonagem(int id)
    {
        var itens = _db.Personagens_Itens.Where(pi => pi.IdPersonagem == id).AsNoTracking().ToList();
        return Json(itens);
    }

    public IActionResult MostrarItensPersonagem()
    {
        return View();
    }

    [HttpGet]
    public ActionResult Escolher(int IdPersonagem)
    {
        var personagem = _db.Personagens.Find(IdPersonagem);
        ViewBagdeCria();
        var personagem_arma = new Personagem_Arma();
        var personagem_armadura = new Personagem_Armadura();
        var personagem_item = new Personagem_Item();
        return View(personagem);
    }

    public void ViewBagdeCria()
    {
        var listaitem = _db.Itens.AsNoTracking().ToList();
        var listaarma = _db.Armas.AsNoTracking().ToList();
        var listaarmadura = _db.Armaduras.AsNoTracking().ToList();
        var listatipoarma = _db.TiposArmas.AsNoTracking().ToList();
        var listatipoarmadura = _db.TiposArmaduras.AsNoTracking().ToList();
        ViewBag.listaitem = listaitem;
        ViewBag.listaarma = listaarma;
        ViewBag.listaarmadura = listaarmadura;
        ViewBag.listatipoarma = listatipoarma;
        ViewBag.listatipoarmadura = listatipoarmadura;
    }
    [HttpPost]
    public ActionResult EscolherItem(Personagem personagem, int IdPersonagem, List<int> armas, List<int> armaduras, List<int> itens)
    {
        var varoriginal = _db.Personagens.Find(IdPersonagem);
        // Barbaro
        if (varoriginal.IdClasse == 1)
        {
            armas.AddRange(new int[] { 2, 2, 2, 2 });
            itens.Add(138);
            if (armas.Contains(8))
            {
                armas.Add(8);
            }
        }
        // Bardo
        else if (varoriginal.IdClasse == 2)
        {
            armaduras.Add(2);
            armas.Add(1);
        }
        // Bruxo
        else if (varoriginal.IdClasse == 3)
        {
            armaduras.Add(2);
            if (armas.Contains(12))
            {
                for (var i = 1; i <= 20; i++)
                {
                    itens.Add(62);
                }
            }
            armas.AddRange(new int[] { 1, 1 });
        }
        // Clerigo
        else if (varoriginal.IdClasse == 4)
        {
            armaduras.Add(13);
            itens.Add(138);
            if (armas.Contains(12))
            {
                for (var i = 1; i <= 20; i++)
                {
                    itens.Add(62);
                }
            }
        }
        // Druida
        else if (varoriginal.IdClasse == 5)
        {
            itens.Add(138);
            armaduras.Add(2);
        }
        // Feiticeiro
        else if (varoriginal.IdClasse == 6)
        {
            if (armas.Contains(12))
            {
                for (var i = 1; i <= 20; i++)
                {
                    itens.Add(62);
                }
            }
        }
        // Guerreiro
        else if (varoriginal.IdClasse == 7)
        {
            if (armas.Count() > 1)
            {
                var repetir = armas.Last();
                armas.Add(repetir);
            }
            else if (armas.Count() == 1)
            {
                armaduras.Add(13);
            }
            if (armaduras.Contains(4))
            {
                armas.Add(32);
                for (var i = 1; i <= 20; i++)
                {
                    itens.Add(61);
                }
            }
            if (armas.Contains(12))
            {
                for (var i = 1; i <= 20; i++)
                {
                    itens.Add(62);
                }
            }

        }
        // Ladino
        else if (varoriginal.IdClasse == 8)
        {
            if (armas.Contains(32))
            {
                for (var i = 1; i <= 20; i++)
                {
                    itens.Add(61);
                }
            }
            armaduras.Add(2);
            armas.AddRange(new int[] { 1, 1 });
            itens.Add(117);
        }
        // Mago
        else if (varoriginal.IdClasse == 9)
        {
            itens.Add(46);
        }
        // Monge
        else if (varoriginal.IdClasse == 10)
        {
            for (var i = 1; i <= 10; i++)
            {
                armas.Add(13);
            }
        }
        // Paladino
        else if (varoriginal.IdClasse == 11)
        {
            if (armas.Contains(2))
            {
                for (var i = 1; i <= 4; i++)
                {
                    armas.Add(2);
                }
            }
            armaduras.Add(13);
            armaduras.Add(10);
        }
        // Patrulheiro
        else if (varoriginal.IdClasse == 12)
        {
            var repetir = armas.Last();
            armas.Add(repetir);
            armas.Add(32);
            for (var i = 1; i <= 20; i++)
            {
                itens.Add(61);
            }
        }

        foreach (var arma in armas)
        {
            var personagem_arma = new Personagem_Arma();
            if (_db.Personagens_Armas.Find(IdPersonagem, arma) is null)
            {
                personagem_arma.SetPersonagem_Arma(IdPersonagem, arma);
                _db.Personagens_Armas.Add(personagem_arma);
            }
            else
            {
                _db.Personagens_Armas.Find(IdPersonagem, arma).MudarQtdPersonagem_Arma();
            }
        }
        foreach (var armadura in armaduras)
        {
            var personagem_armadura = new Personagem_Armadura();
            if (_db.Personagens_Armas.Find(IdPersonagem, armadura) is null)
            {
                personagem_armadura.SetPersonagem_Armadura(IdPersonagem, armadura);
                _db.Personagens_Armaduras.Add(personagem_armadura);
            }
            else
            {
                _db.Personagens_Armaduras.Find(IdPersonagem, armadura).MudarQtdPersonagem_Armadura();
            }

        }
        foreach (var item in itens)
        {
            var personagem_item = new Personagem_Item();
            if (_db.Personagens_Itens.Find(IdPersonagem, item) is null)
            {
                personagem_item.SetPersonagem_Item(IdPersonagem, item);
                _db.Personagens_Itens.Add(personagem_item);
            }
            else
            {
                _db.Personagens_Itens.Find(IdPersonagem, item).MudarQtdPersonagem_Item();
            }
        }
        if (varoriginal is null)
        {
            return RedirectToAction("Index");
        }
        if(varoriginal.EscolheuEquip == 0){
            varoriginal.EscolheuEquip = 1;
        }
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }
    // [HttpPost]
    // public ActionResult AlterarItem(int IdPersonagem, Personagem personagem, List<int> armas, List<int> armaduras, List<int> itens, bool IsEquipada, int Qtd)
    // {
    //     foreach (var arma in armas)
    //     {
    //         var personagem_arma = new Personagem_Arma();
    //         if (_db.Personagens_Armas.Find(IdPersonagem, arma) is null)
    //         {
    //             personagem_arma.SetPersonagem_Arma(IdPersonagem, arma);
    //             _db.Personagens_Armas.Add(personagem_arma);
    //         }
    //         else
    //         {
    //             _db.Personagens_Armas.Find(IdPersonagem, arma).MudarQtdPersonagem_Arma(Qtd);
    //         }
    //     }
    //     foreach (var armadura in armaduras)
    //     {
    //         var personagem_armadura = new Personagem_Armadura();
    //         if (_db.Personagens_Armas.Find(IdPersonagem, armadura) is null)
    //         {
    //             personagem_armadura.SetPersonagem_Armadura(IdPersonagem, armadura);
    //             _db.Personagens_Armaduras.Add(personagem_armadura);
    //         }
    //         else
    //         {
    //             _db.Personagens_Armaduras.Find(IdPersonagem, armadura).MudarQtdPersonagem_Armadura(Qtd);
    //         }

    //     }
    //     foreach (var item in itens)
    //     {
    //         var personagem_item = new Personagem_Item();
    //         if (_db.Personagens_Itens.Find(IdPersonagem, item) is null)
    //         {
    //             personagem_item.SetPersonagem_Item(IdPersonagem, item);
    //             _db.Personagens_Itens.Add(personagem_item);
    //         }
    //         else
    //         {
    //             _db.Personagens_Itens.Find(IdPersonagem, item).MudarQtdPersonagem_Item(Qtd);
    //         }
    //     }
    //     _db.SaveChanges();
    //     return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    // }
    [HttpPost]
    public ActionResult AlterarItem(int IdPersonagem, Personagem personagem, int arma, int armadura, int item, bool IsEquipada, int Qtd)
    {
        if (arma != 0)
        {
            var personagem_arma = new Personagem_Arma();
            if (_db.Personagens_Armas.Find(IdPersonagem, arma) is null)
            {
                personagem_arma.SetPersonagem_Arma(IdPersonagem, arma);
                _db.Personagens_Armas.Add(personagem_arma);
                if (IsEquipada == true)
                {
                    _db.Personagens_Armas.Find(IdPersonagem, arma).IsEquipada = IsEquipada;
                }
            }
            else
            {
                _db.Personagens_Armas.Find(IdPersonagem, arma).MudarQtdPersonagem_Arma(Qtd);
                if (_db.Personagens_Armas.Find(IdPersonagem, arma).IsEquipada != IsEquipada)
                {
                    _db.Personagens_Armas.Find(IdPersonagem, arma).IsEquipada = IsEquipada;
                }
            }
        }
        if (armadura != 0)
        {
            var personagem_armadura = new Personagem_Armadura();
            if (_db.Personagens_Armaduras.Find(IdPersonagem, armadura) is null)
            {
                personagem_armadura.SetPersonagem_Armadura(IdPersonagem, armadura);
                _db.Personagens_Armaduras.Add(personagem_armadura);
                if (IsEquipada == true)
                {
                    _db.Personagens_Armaduras.Find(IdPersonagem, armadura).IsEquipada = IsEquipada;
                }
            }
            else
            {
                _db.Personagens_Armaduras.Find(IdPersonagem, armadura).MudarQtdPersonagem_Armadura(Qtd);
                if (_db.Personagens_Armaduras.Find(IdPersonagem, armadura).IsEquipada != IsEquipada)
                {
                    _db.Personagens_Armaduras.Find(IdPersonagem, armadura).IsEquipada = IsEquipada;
                }
            }
        }
        if (item != 0)
        {
            var personagem_item = new Personagem_Item();
            if (_db.Personagens_Itens.Find(IdPersonagem, item) is null)
            {
                personagem_item.SetPersonagem_Item(IdPersonagem, item);
                _db.Personagens_Itens.Add(personagem_item);
            }
            else
            {
                _db.Personagens_Itens.Find(IdPersonagem, item).MudarQtdPersonagem_Item(Qtd);
            }
        }
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }
    public ActionResult AlterarInventario(int IdPersonagem, Personagem personagem, int arma, int armadura, int item, bool IsEquipada, int Qtd, bool Deletar)
    {
        if (Deletar is true)
        {
            if (arma != 0)
            {
                var personagem_arma = new Personagem_Arma();
                personagem_arma = _db.Personagens_Armas.Find(IdPersonagem, arma);
                _db.Personagens_Armas.Remove(personagem_arma);
            }
            if (armadura != 0)
            {
                var personagem_armadura = new Personagem_Armadura();
                personagem_armadura = _db.Personagens_Armaduras.Find(IdPersonagem, armadura);
                _db.Personagens_Armaduras.Remove(personagem_armadura);
            }
            if (item != 0)
            {
                var personagem_item = new Personagem_Item();
                personagem_item = _db.Personagens_Itens.Find(IdPersonagem, item);
                _db.Personagens_Itens.Remove(personagem_item);
            }
        }
        else if (Deletar is false)
        {
            if (arma != 0)
            {
                var personagem_arma = new Personagem_Arma();
                if (_db.Personagens_Armas.Find(IdPersonagem, arma) is null)
                {
                    personagem_arma.SetPersonagem_Arma(IdPersonagem, arma);
                    _db.Personagens_Armas.Add(personagem_arma);
                }
                else
                {
                    _db.Personagens_Armas.Find(IdPersonagem, arma).MudarQtdPersonagem_Arma(Qtd);
                    if (_db.Personagens_Armas.Find(IdPersonagem, arma).IsEquipada != IsEquipada)
                    {
                        _db.Personagens_Armas.Find(IdPersonagem, arma).IsEquipada = IsEquipada;
                    }
                }
            }
            if (armadura != 0)
            {
                var personagem_armadura = new Personagem_Armadura();
                if (_db.Personagens_Armaduras.Find(IdPersonagem, armadura) is null)
                {
                    personagem_armadura.SetPersonagem_Armadura(IdPersonagem, armadura);
                    _db.Personagens_Armaduras.Add(personagem_armadura);
                }
                else
                {
                    _db.Personagens_Armaduras.Find(IdPersonagem, armadura).MudarQtdPersonagem_Armadura(Qtd);
                    if (_db.Personagens_Armaduras.Find(IdPersonagem, armadura).IsEquipada != IsEquipada)
                    {
                        _db.Personagens_Armaduras.Find(IdPersonagem, armadura).IsEquipada = IsEquipada;
                    }
                }
            }
            if (item != 0)
            {
                var personagem_item = new Personagem_Item();
                if (_db.Personagens_Itens.Find(IdPersonagem, item) is null)
                {
                    personagem_item.SetPersonagem_Item(IdPersonagem, item);
                    _db.Personagens_Itens.Add(personagem_item);
                }
                else
                {
                    _db.Personagens_Itens.Find(IdPersonagem, item).MudarQtdPersonagem_Item(Qtd);
                }
            }
        }
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }
}