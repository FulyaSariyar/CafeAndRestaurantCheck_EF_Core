using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.ViewModels
{
    public class KategoriViewModel
    {
        public string Ad { get; set; }  
        public string? Aciklama { get; set; }
        public byte[] Fotograf { get; set; }
    }
}
