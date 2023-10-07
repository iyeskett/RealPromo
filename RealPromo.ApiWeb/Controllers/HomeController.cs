using Microsoft.AspNetCore.Mvc;
using RealPromo.ApiWeb.Models;
using System.Diagnostics;

namespace RealPromo.ApiWeb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Promocao()
        {
            return View();
        }

        public IActionResult CadastrarPromocao()
        {
            return View();
        }
    }
}