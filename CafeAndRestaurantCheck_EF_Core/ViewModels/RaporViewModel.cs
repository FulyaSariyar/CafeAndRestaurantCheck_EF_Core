using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.ViewModels
{
    public class RaporViewModel
    {
        public string Ad { get; set; }
       // public DateTime? CreatedDate { get; set; }
        public decimal BirimFiyat { get; set; }
        public int Adet { get; set; } = 1;
        public decimal AraToplam { get; set; }
    }
}
