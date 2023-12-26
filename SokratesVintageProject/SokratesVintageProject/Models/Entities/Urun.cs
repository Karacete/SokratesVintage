using System;
using System.Collections.Generic;

namespace SokratesVintageProject.Models.Entities
{
    public partial class Urun
    {
        public int UrunId { get; set; }
        public string? UrunAd { get; set; } = null!;
        public int? UrunKategori { get; set; }
        public decimal UrunFiyat { get; set; }
        public string? UrunFotograf { get; set; }
        public int? Sepet { get; set; }

        public virtual Sepet? SepetNavigation { get; set; }
        public virtual Kategori? UrunKategoriNavigation { get; set; }
    }
}
