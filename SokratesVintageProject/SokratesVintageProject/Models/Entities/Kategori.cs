using System;
using System.Collections.Generic;

namespace SokratesVintageProject.Models.Entities
{
    public partial class Kategori
    {
        public Kategori()
        {
            Uruns = new HashSet<Urun>();
        }

        public int KategoriId { get; set; }
        public string KategoriAd { get; set; } = null!;

        public virtual ICollection<Urun> Uruns { get; set; }
    }
}
