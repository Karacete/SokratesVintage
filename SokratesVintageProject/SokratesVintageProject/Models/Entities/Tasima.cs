using System;
using System.Collections.Generic;

namespace SokratesVintageProject.Models.Entities
{
    public partial class Tasima
    {
        public int KargoId { get; set; }
        public string? KargoAd { get; set; }
        public int? Musteri { get; set; }
        public int? Urun { get; set; }
        public int Adres { get; set; }
        public decimal? TasimaUcret { get; set; }

        public virtual Satis Kargo { get; set; } = null!;
    }
}
