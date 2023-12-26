using SokratesVintageProject.Models.Entities;

namespace SokratesVintageProject.Models
{
    public class UrunModel
    {
        public int UrunId { get; set; }
        public string? UrunAd { get; set; }
        public int UrunKategori {  get; set; }
        public decimal UrunFiyat {  get; set; }
        public IFormFile? UrunFotograf {  get; set; }
        public List<Urun>? Urun { get; set; }
    }
}
