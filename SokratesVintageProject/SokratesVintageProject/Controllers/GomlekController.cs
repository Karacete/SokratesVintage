using Microsoft.AspNetCore.Mvc;
using SokratesVintageProject.Models.Context;
namespace SokratesVintageProject.Controllers
{
    public class GomlekController : Controller
    {
        SokratesVintageDatabaseContext db = new SokratesVintageDatabaseContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Gomlek()
        {
            var deger = db.Uruns.ToList();
            return View(deger);
        }
    }
}
