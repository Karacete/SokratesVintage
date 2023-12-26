using Microsoft.AspNetCore.Mvc;
using SokratesVintageProject.Models;
using System.Diagnostics;
using SokratesVintageProject.Models.Context;

namespace SokratesVintageProject.Controllers
{
    public class HomeController : Controller
    {
        SokratesVintageDatabaseContext db = new SokratesVintageDatabaseContext();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
        public IActionResult Hakkinda()
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
