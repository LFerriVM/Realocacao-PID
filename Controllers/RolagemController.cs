using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Projeto.Controllers;

public class RolagemController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}