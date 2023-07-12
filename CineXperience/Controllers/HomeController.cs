using CineXperience.DataBase;
using CineXperience.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CineXperience.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CineXperienceContext _context;

        public HomeController(ILogger<HomeController> logger, CineXperienceContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var peliculas = _context.Pelicula.ToList();

            return View(peliculas);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}