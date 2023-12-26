using System;
using System.Collections.Generic;

namespace SokratesVintageProject.Models.Entities
{
    public partial class Sepet
    {
        public Sepet()
        {
            Uruns = new HashSet<Urun>();
        }

        public int SepetId { get; set; }
        public int? Musteri { get; set; }
        public string? UrunAd { get; set; }
        public decimal? UrunFiyat { get; set; }
        public string? UrunFotograf { get; set; }
        public int? UrunMiktar { get; set; }

        public virtual Musteri? MusteriNavigation { get; set; }
        public virtual ICollection<Urun> Uruns { get; set; }
    }
}
