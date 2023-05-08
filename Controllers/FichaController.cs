using Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Projeto.Controllers;

public class FichaController : Controller
{
    private DataContext _db;
    public FichaController(DataContext db)
    {
        _db = db;
    }
    [Authorize]
    public ActionResult Exibir(int? IdPersonagem, int? IdUsuario)
    {
        var usuario = _db.Usuarios.FirstOrDefault(u=> u.Email == HttpContext.User.Identity.Name);
        ViewBagdeCria();
        if (IdPersonagem is not null)
        {
            var personagemexiste = _db.Personagens.Include(c => c.Classe).Include(r => r.Raca).Include(sr => sr.SubRaca).Include(a => a.Antecedente).Include(sk => sk.Skin).Include(u => u.Usuario).FirstOrDefault(p => p.IdPersonagem == IdPersonagem);
            if(personagemexiste.IdUsuario != usuario.IdUsuario)
            {
                return Content("Você não tem permissão");
            }
            return View(personagemexiste);
        }
        var personagemnaoexiste = new Personagem();
        personagemnaoexiste.IdUsuario = usuario.IdUsuario;
        _db.Personagens.Add(personagemnaoexiste);
        _db.SaveChanges();
        return RedirectToRoute(new { controller = "Ficha", action = "Exibir", IdPersonagem = personagemnaoexiste.IdPersonagem });
    }
    public void ViewBagdeCria()
    {
        var usuario = _db.Usuarios.FirstOrDefault(u => u.Email == HttpContext.User.Identity.Name);
        ViewBag.usuariologado = usuario;
        var listaraca = _db.Racas.Include(i => i.Idioma).AsNoTracking().ToList();
        var listausuario = _db.Usuarios.AsNoTracking().ToList();
        var listasubraca = _db.SubRacas.Include(r => r.Raca).AsNoTracking().ToList();
        var listaitem = _db.Itens.AsNoTracking().ToList();
        var listapersonagemitem = _db.Personagens_Itens.Include(p => p.Personagem).Include(i => i.Item).AsNoTracking().ToList();
        var listaarma = _db.Armas.Include(tp => tp.TipoArma).AsNoTracking().ToList();
        var listapersonagemarma = _db.Personagens_Armas.Include(p => p.Personagem).Include(a => a.Arma).AsNoTracking().ToList();
        var listaarmadura = _db.Armaduras.Include(tp => tp.TipoArmadura).AsNoTracking().ToList();
        var listapersonagemarmadura = _db.Personagens_Armaduras.Include(p => p.Personagem).Include(a => a.Armadura).AsNoTracking().ToList();
        var listaclasse = _db.Classes.Include(l => l.ListaMagia).AsNoTracking().ToList();
        var listaclassetracosdeclasse = _db.Classes_TracosdeClasses.Include(c => c.Classe).Include(t => t.TracodeClasse).AsNoTracking().ToList();
        var listatracodeclassearquetipo = _db.TracosdeClasse_Arquetipos.Include(a => a.Arquetipo).Include(t => t.TracodeClasse).AsNoTracking().ToList();
        var listaantecedente = _db.Antecedentes.AsNoTracking().ToList();
        var listahabilidade = _db.HabilidadesRaciais.AsNoTracking().ToList();
        var listahabilidaderaca = _db.HabilidadesRaciais_Racas.Include(h => h.HabilidadeRacial).Include(r => r.Raca).AsNoTracking().ToList();
        var listahabilidadesubraca = _db.HabilidadesRaciais_SubRacas.Include(h => h.HabilidadeRacial).Include(sr => sr.SubRaca).AsNoTracking().ToList();
        var listaproficienciaarma = _db.Proficiencias_Armas.Include(p => p.Personagem).Include(a => a.Arma).AsNoTracking().ToList();
        var listaproficienciaarmadura = _db.Proficiencias_Armaduras.Include(p => p.Personagem).Include(a => a.Armadura).AsNoTracking().ToList();
        var listaproficienciaitem = _db.Proficiencias_Itens.Include(p => p.Personagem).Include(i => i.Item).AsNoTracking().ToList();
        var listaidioma = _db.Idiomas.AsNoTracking().ToList();
        var listaidiomapersonagem = _db.Idiomas_Personagens.Include(i => i.Idioma).Include(p => p.Personagem).AsNoTracking().ToList();
        var listaveiculoterrestre = _db.VeiculosTerrestres.AsNoTracking().ToList();
        var listaveiculoaquatico = _db.VeiculosAquaticos.AsNoTracking().ToList();
        var listamagialistamagia = _db.Magias_ListasMagias.AsNoTracking().ToList();
        ViewBag.listamagialistamagia = listamagialistamagia;
        var listalistamagia = _db.ListasMagias.AsNoTracking().ToList();
        ViewBag.listalistamagia = listalistamagia;
        var listamagia = _db.Magias.AsNoTracking().ToList();
        ViewBag.listamagia = listamagia;
        ViewBag.listaclasse = listaclasse;
        ViewBag.listaclassetracosdeclasse = listaclassetracosdeclasse;
        ViewBag.listatracodeclassearquetipo = listatracodeclassearquetipo;
        ViewBag.listaitem = listaitem;
        ViewBag.listapersonagemitem = listapersonagemitem;
        ViewBag.listaarma = listaarma;
        ViewBag.listapersonagemarma = listapersonagemarma;
        ViewBag.listaarmadura = listaarmadura;
        ViewBag.listapersonagemarmadura = listapersonagemarmadura;
        ViewBag.listaraca = listaraca;
        ViewBag.listausuario = listausuario;
        ViewBag.listasubraca = listasubraca;
        ViewBag.listaantecedente = listaantecedente;
        ViewBag.listahabilidade = listahabilidade;
        ViewBag.listahabilidaderaca = listahabilidaderaca;
        ViewBag.listahabilidadesubraca = listahabilidadesubraca;
        ViewBag.listaproficienciaarma = listaproficienciaarma;
        ViewBag.listaproficienciaarmadura = listaproficienciaarmadura;
        ViewBag.listaproficienciaitem = listaproficienciaitem;
        ViewBag.listaidioma = listaidioma;
        ViewBag.listaidiomapersonagem = listaidiomapersonagem;
        ViewBag.listaveiculoterrestre = listaveiculoterrestre;
        ViewBag.listaveiculoaquatico = listaveiculoaquatico;

        var listatraco = _db.TracosdeClasse.AsNoTracking().ToList();
        var listaarquetipo = _db.Arquetipos.AsNoTracking().ToList();
        var listatipoarma = _db.TiposArmas.AsNoTracking().ToList();
        var listatipoarmadura = _db.TiposArmaduras.AsNoTracking().ToList();

        ViewBag.listatraco = listatraco;
        ViewBag.listaarquetipo = listaarquetipo;

        ViewBag.listatipoarma = listatipoarma;
        ViewBag.listatipoarmadura = listatipoarmadura;
    }

}