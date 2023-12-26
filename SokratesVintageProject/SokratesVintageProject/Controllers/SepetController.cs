using Microsoft.AspNetCore.Mvc;
using SokratesVintageProject.Models;
using SokratesVintageProject.Models.Context;
namespace SokratesVintageProject.Controllers
{
    public class SepetController : Controller
    {
        SokratesVintageDatabaseContext db = new SokratesVintageDatabaseContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Sepet(SepetModel sepetModel)
        {
           
            return View();
        }
    }
}
