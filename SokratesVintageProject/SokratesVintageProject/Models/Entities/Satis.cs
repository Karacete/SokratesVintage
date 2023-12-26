using System;
using System.Collections.Generic;

namespace SokratesVintageProject.Models.Entities
{
    public partial class Satis
    {
        public Satis()
        {
            Tasimas = new HashSet<Tasima>();
        }

        public int SatisId { get; set; }
        public int? Urun { get; set; }
        public int? Musteri { get; set; }
        public byte? Adet { get; set; }
        public decimal? Fiyat { get; set; }

        public virtual Musteri? MusteriNavigation { get; set; }
        public virtual ICollection<Tasima> Tasimas { get; set; }
    }
}
