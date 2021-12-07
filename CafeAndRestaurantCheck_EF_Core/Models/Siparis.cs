using CafeAndRestaurantCheck_EF_Core.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Models
{
    public class Siparis: BaseEntity, IKey<int>
    {
        [Key]
        public int Id { get; set; }
        public Urun Urun { get; set; }
        public int Adet { get; set; }
        public decimal Fiyat { get; set; }
        public string MasaAd { get; set; }
        public decimal AraToplam { get => Adet * Fiyat; }
    }
}
