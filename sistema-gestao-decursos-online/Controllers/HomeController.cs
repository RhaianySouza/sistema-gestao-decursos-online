/**
 * Controller: HomeController
 * Descrição: Controla as ações relacionadas à página inicial e demais rotas gerais da aplicação.
 * Data de Criação: 29/04/2025
 */
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using sistema_gestao_decursos_online.Models;

namespace sistema_gestao_decursos_online.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Message"] = "Seja bem-vindo as definições de politica de privacidade da nossa página";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Sistema de Gestão de Cursos Online";
            return View();
        }
        public IActionResult Contact()
        {
            ViewData["Message"] = "Entre em contato com a gente!";
            return View();
        }

    }
}
