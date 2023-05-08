using Data;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Controllers;

public class PersonagemController : Controller
{
    private DataContext _db;
    public PersonagemController(DataContext db)
    {
        _db = db;
    }
    [HttpGet]
    public ActionResult InserirBio()
    {
        var personagem = new Personagem();
        return View(personagem);
    }
    [HttpPost]
    public ActionResult InserirBio(Personagem personagem)
    {
        if (!ModelState.IsValid)
        {
            return View(personagem);
        }
        _db.Personagens.Add(personagem);
        _db.SaveChanges();
        return RedirectToAction("Escolher", "Raca", new { personagem.IdPersonagem });
    }
    [HttpPost]
    public ActionResult EscolherNome(int IdPersonagem, Personagem personagem)
    {
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        personagemoriginal.Nome = personagem.Nome;
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new {personagem.IdPersonagem});
    }
    [HttpPost]
    public ActionResult EscolherTendencia(int IdPersonagem, Personagem personagem)
    {
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        personagemoriginal.Tendencia = personagem.Tendencia;
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new {personagem.IdPersonagem});
    }
    [HttpPost]
    public ActionResult EscolherDinheiro(int IdPersonagem, Personagem personagem)
    {
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        if(personagem.PC >= 0){
            personagemoriginal.PC = personagem.PC;
        }
        else if(personagem.PC < 0)
        {
             personagemoriginal.PC = 0;
        }
        
        if(personagem.PP >= 0){
            personagemoriginal.PP = personagem.PP;
        }
        else if(personagem.PP < 0)
        {
            personagemoriginal.PP = 0;
        }
        
        if(personagem.PE >= 0){
            personagemoriginal.PE = personagem.PE;
        }
        else if(personagem.PE < 0)
        {
            personagemoriginal.PE = 0;
        }
        
        if(personagem.PO >= 0){
            personagemoriginal.PO = personagem.PO;
        }
        else if(personagem.PO < 0)
        {
            personagemoriginal.PO = 0;
        }
        
        if(personagem.PL >= 0){
            personagemoriginal.PL = personagem.PL;
        }
        else if(personagem.PL < 0)
        {
            personagemoriginal.PL = 0;
        }
        
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }

    [HttpPost]
    public ActionResult AlterarNivel(int IdPersonagem, Personagem personagem)
    {
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        personagemoriginal.Nivel = personagem.Nivel;
        personagemoriginal.DefinirBonusdeProficiencia();
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }

    [HttpPost]
    public ActionResult AlterarTraco(int IdPersonagem, Personagem personagem)
    {
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        personagemoriginal.Traco = personagem.Traco;
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }

    [HttpPost]
    public ActionResult AlterarIdeal(int IdPersonagem, Personagem personagem)
    {
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        personagemoriginal.Ideal = personagem.Ideal;
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }

    [HttpPost]
    public ActionResult AlterarVinculo(int IdPersonagem, Personagem personagem)
    {
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        personagemoriginal.Vinculo = personagem.Vinculo;
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }

    [HttpPost]
    public ActionResult AlterarDefeito(int IdPersonagem, Personagem personagem)
    {
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        personagemoriginal.Defeito = personagem.Defeito;
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }
    [HttpPost]
    public ActionResult setVidaTotal(int IdPersonagem, int DadoVida, Personagem personagem)
    {
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        personagemoriginal.setVidaTotal(DadoVida);
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }
    [HttpPost]
    public ActionResult setVidaAtual(int IdPersonagem, int VidaAtual, Personagem personagem)
    {
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        personagemoriginal.setVidaAtual(VidaAtual);
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new { personagem.IdPersonagem });
    }
    [HttpPost]
    public ActionResult Salvaguarda(int IdPersonagem, Personagem personagem, int? TestesBemSucedidos, int? TestesMalSucedidos){
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        if(TestesBemSucedidos is not null)
        {
            personagemoriginal.MudarTestesBemSucedidos(Convert.ToInt32(TestesBemSucedidos));
        }else if(TestesMalSucedidos is not null){
            personagemoriginal.MudarTestesMalSucedidos(Convert.ToInt32(TestesMalSucedidos));
        }
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new{ personagem.IdPersonagem});
    }
    [HttpPost]
    public ActionResult Reviver(int IdPersonagem, Personagem personagem){
        var personagemoriginal = _db.Personagens.Find(IdPersonagem);
        personagemoriginal.VidaAtual = 1;
        personagemoriginal.TestesBemSucedidos = 0;
        personagemoriginal.TestesMalSucedidos = 0;
        personagemoriginal.Morto = false;
        _db.SaveChanges();
        return RedirectToAction("Exibir", "Ficha", new{ personagem.IdPersonagem });
    }
}