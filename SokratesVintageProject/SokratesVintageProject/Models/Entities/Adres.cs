using System;
using System.Collections.Generic;

namespace SokratesVintageProject.Models.Entities
{
    public partial class Adres
    {
        public int Musteri { get; set; }
        public string? MusteriIl { get; set; }
        public string? MusteriIlce { get; set; }
        public string? MusteriMahalle { get; set; }
        public string? MusteriCadde { get; set; }
        public string? MusteriSokak { get; set; }
        public string? MusteriApartman { get; set; }
        public byte? MusteriKapiNumara { get; set; }

        public virtual Musteri Musteri1 { get; set; } = null!;
        public virtual Tasima MusteriNavigation { get; set; } = null!;
    }
}
