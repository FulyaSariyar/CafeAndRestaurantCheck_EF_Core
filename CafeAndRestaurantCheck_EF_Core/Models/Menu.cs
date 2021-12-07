using CafeAndRestaurantCheck_EF_Core.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Models
{
    public class Menu:BaseEntity, IKey<int>
    {
        [Key]
        public int Id { get; set; }
        public byte[] Fotograf { get; set; }
        public string UrunAd { get; set; }
        public string Fiyat { get; set; }
        public string UrunKategori { get; set; }
        public override string ToString() => $"{UrunAd} {Fiyat}";

    }
}
