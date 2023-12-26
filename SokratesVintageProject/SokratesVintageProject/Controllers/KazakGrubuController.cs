using Microsoft.AspNetCore.Mvc;
using SokratesVintageProject.Models.Context;
namespace SokratesVintageProject.Controllers
{
    public class KazakGrubuController : Controller
    {
        SokratesVintageDatabaseContext db = new SokratesVintageDatabaseContext();

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Kazak()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
        public IActionResult Sweatshirt()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
    }
}
