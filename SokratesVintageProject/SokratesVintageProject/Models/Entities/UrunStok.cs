using System;
using System.Collections.Generic;

namespace SokratesVintageProject.Models.Entities
{
    public partial class UrunStok
    {
        public int? Urun { get; set; }
        public int? UrunStokDurumu { get; set; }
        public int? DepoCalisani { get; set; }
    }
}
