using Microsoft.AspNetCore.Mvc;
using SokratesVintageProject.Models;
using SokratesVintageProject.Models.Context;
using SokratesVintageProject.Models.Entities;

namespace SokratesVintageProject.Controllers
{
    public class GirisController : Controller
    {
        SokratesVintageDatabaseContext db = new SokratesVintageDatabaseContext();
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GirisYap(GirisModel girisModel)
        {
            var deger = db.Musteris.ToList();
            foreach (var musteri in deger)
            {
                if (girisModel.Soyisim == musteri.MusteriSoyad && girisModel.TelefonNumara == musteri.MusteriTelefonNumara)
                {
                    HttpContext.Session.SetString("MusteriIsim", musteri.MusteriAd);
                    HttpContext.Session.SetInt32("MusteriId", musteri.MusteriId);
                    return RedirectToAction("Index", "Home",HttpContext.Session.GetString("MusteriIsim"));
                }
            }
            return View();
        }
        public IActionResult KayitOl()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KayitOl(KayitModel kayitModel)
        {
            var deger = db.Musteris.ToList();
            {
                Musteri yeni = new Musteri();
                bool ayniMi = false;
                foreach (var musteri in deger)
                {
                    ayniMi = false;
                    bool dd = kayitModel.MusteriTelefonNumara == musteri.MusteriTelefonNumara;
                    if (!dd)
                    {
                        ayniMi = true;

                        yeni.MusteriAd = kayitModel.MusteriAd;
                        yeni.MusteriSoyad = kayitModel.MusteriSoyad;
                        yeni.MusteriTelefonNumara = kayitModel.MusteriTelefonNumara;
                    }
                }
                if (ayniMi)
                {
                    db.Add(yeni);
                    db.SaveChanges();
                    return RedirectToAction("GirisYap", "Giris");
                }
            }
            return View();
        }
    }
}
