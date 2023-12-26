using Microsoft.AspNetCore.Mvc;
using SokratesVintageProject.Models.Context;

namespace SokratesVintageProject.Controllers
{
    public class CeketveMontController : Controller
    {
        SokratesVintageDatabaseContext db = new SokratesVintageDatabaseContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Deri()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
        public IActionResult Mont()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
        public IActionResult EsofmanUstu()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
        public IActionResult Yagmurluk()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
        public IActionResult Mevsimlik()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
        public IActionResult Kurk()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
    }
}
