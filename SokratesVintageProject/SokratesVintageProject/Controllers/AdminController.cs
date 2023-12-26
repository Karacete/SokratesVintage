using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SokratesVintageProject.Models;
using SokratesVintageProject.Models.Context;
using SokratesVintageProject.Models.Entities;
using System.Security.Claims;
namespace SokratesVintageProject.Controllers
{
    public class AdminController : Controller
    {
        SokratesVintageDatabaseContext db = new SokratesVintageDatabaseContext();
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(AdminModel adminModel)
        {
            if (adminModel.Email == "admin@admin.com" && adminModel.Sifre == "Admin1234?")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,adminModel.Email)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("MusteriListesi", "Admin");
            }
            else
            {
                return View();
            }
            
        }

        [Authorize]

        public IActionResult MusteriListesi()
        {
            MusteriModel deger = new MusteriModel();
            deger.Musteri = db.Musteris.ToList();
            return View(deger);
        }
        [HttpPost]
        public IActionResult MusteriListesi(MusteriModel musteriModel)
        {
            var deger = db.Musteris.ToList();
            Musteri silinen = db.Musteris.First(x => x.MusteriId == musteriModel.MsId);
            db.Musteris.Remove(silinen);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult UrunListesi()
        {
            UrunModel deger = new UrunModel();
            deger.Urun = db.Uruns.ToList();
            return View(deger);
        }
        [HttpPost]
        public IActionResult UrunListesi(UrunModel urunModel)
        {
            var deger = db.Uruns.ToList();
            Urun silinen = db.Uruns.First(x => x.UrunId == urunModel.UrunId);
            db.Uruns.Remove(silinen);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult UrunEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UrunEkle(UrunModel urunModel)
        {
            var deger = new Urun();
            if(urunModel.UrunFotograf != null)
            {
                var extension = Path.GetExtension(urunModel.UrunFotograf.FileName);
                var newimagename = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/css/resimler/urun", newimagename);
                var stream = new FileStream(location, FileMode.Create);
                urunModel.UrunFotograf.CopyTo(stream);
                deger.UrunFotograf = "/css/resimler/urun/" + newimagename;
            }
            deger.UrunAd = urunModel.UrunAd;
            deger.UrunKategori=urunModel.UrunKategori;
            deger.UrunFiyat=urunModel.UrunFiyat;
            db.Uruns.Add(deger);
            db.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }
        public IActionResult  UrunGuncelle()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult UrunGuncelle(UrunModel urunModel)
        {
            var deger = db.Uruns.ToList();
            Urun guncellenen = db.Uruns.First(x => x.UrunId == urunModel.UrunId);
            if(guncellenen != null) 
            {
                guncellenen.UrunAd = urunModel.UrunAd;
                guncellenen.UrunKategori=urunModel.UrunKategori;
                guncellenen.UrunFiyat= urunModel.UrunFiyat;
                db.SaveChanges();
                return RedirectToAction("Index", "Admin");
            }
            return View();
        }
    }
}
