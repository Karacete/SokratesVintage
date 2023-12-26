using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SokratesVintageProject.Models.Context;
namespace SokratesVintageProject.Controllers
{
    public class YazGrubuController : Controller
    {
        SokratesVintageDatabaseContext db = new SokratesVintageDatabaseContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Tisort()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
        public IActionResult Sort()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
    }
}
