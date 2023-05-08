using System.Security.Claims;
using Data;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Models;
using static BCrypt.Net.BCrypt;

namespace Projeto.Controllers;

public class UsuarioController : Controller
{
    private DataContext _db;
    private readonly IWebHostEnvironment _env;

    public UsuarioController(DataContext db, IWebHostEnvironment env)
    {
        _db = db;
        _env = env;
    }
    public ActionResult Index()
    {
        var usuarios = _db.Usuarios.AsNoTracking().ToList();
        ViewBag.listapersonagem = _db.Personagens.Include(c => c.Classe).Include(r => r.Raca).AsNoTracking().ToList();
        return View(usuarios);
    }
    [HttpGet]
    public ActionResult Login()
    {
        var login = new LoginViewModel();
        return View(login);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel login, string returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            return View(login);
        }
        var usuario = _db.Usuarios.FirstOrDefault(u => u.Email == login.Email);
        if (usuario is null)
        {
            ModelState.AddModelError("Email", "Usuário não encontrado.");
            return View(login);
        }
        //verifica se as senhas hasheadas são iguais
        var verificado = Verify(login.Senha, usuario.Senha);

        if (verificado)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, usuario.Email),
            };
            //cria uma identidade compativel com o módulo de autenticação do ASP NET
            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                AllowRefresh = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                IsPersistent = login.Lembrar,
            };
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProperties);
            Console.WriteLine($"Usuário {usuario.Email} logou ás {DateTime.Now}.");
            if (returnUrl is null)
            {
                return RedirectToAction("Index", "Home");
            }
            return Redirect(returnUrl);
        }
        else{
            return View(login);
        }
    }
    [HttpGet]
    public ActionResult Cadastrar()
    {
        var usuario = new Usuario();
        return View(usuario);
    }
    [HttpPost]
    public ActionResult Cadastrar(Usuario usuario)
    {
        if (!ModelState.IsValid)
        {
            return View(usuario);
        }
        usuario.Senha = HashPassword(usuario.Senha, 10);
        _db.Usuarios.Add(usuario);
        _db.SaveChanges();
        return RedirectToAction("Index", "Home");
    }
    [HttpGet]
    public ActionResult EsqueciaSenha()
    {
        return View();
    }
    // [HttpPost]
    // public ActionResult EsqueciaSenha(Usuario usuario, string senha)
    // {
    //     foreach(var users in usuario){

    //     }
    // }
    [HttpGet]
    public ActionResult Perfil(int IdUsuario)
    {
        var usuario = _db.Usuarios.Find(IdUsuario);
        return View(usuario);
    }
    public async Task<IActionResult> Logout(string returnUrl = null)
    {
        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
        if (returnUrl is null)
        {
            return RedirectToAction("Index", "Home");
        }
        return Redirect(returnUrl);
    }
}