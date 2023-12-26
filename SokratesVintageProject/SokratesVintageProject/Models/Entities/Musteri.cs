using System;
using System.Collections.Generic;

namespace SokratesVintageProject.Models.Entities
{
    public partial class Musteri
    {
        public Musteri()
        {
            Satis = new HashSet<Satis>();
            Sepets = new HashSet<Sepet>();
        }

        public int MusteriId { get; set; }
        public string MusteriAd { get; set; } = null!;
        public string? MusteriSoyad { get; set; }
        public long MusteriTelefonNumara { get; set; }

        public virtual ICollection<Satis> Satis { get; set; }
        public virtual ICollection<Sepet> Sepets { get; set; }
    }
}
