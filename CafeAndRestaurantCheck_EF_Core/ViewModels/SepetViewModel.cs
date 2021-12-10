using CafeAndRestaurantCheck_EF_Core.Data;
using CafeAndRestaurantCheck_EF_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.ViewModels
{
    public class SepetViewModel
    {
        public Urun Urun { get; set; }
        public short Adet { get; set; } = 0;
        public decimal AraToplam => Urun.BirimFiyat * Adet;
        public ListViewButtonColumn Azalt { get; set; }
    }
}
