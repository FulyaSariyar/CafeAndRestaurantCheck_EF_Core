using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Models
{
    public partial class Urun
    {
        public override string ToString()
        {
            return $"{Ad} - {BirimFiyat}";

        }

    }



}
