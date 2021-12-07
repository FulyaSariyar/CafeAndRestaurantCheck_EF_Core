using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Models.Abstracts;
using CafeAndRestaurantCheck_EF_Core.Repository.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Repository
{
    public class UrunRepo : RepositoryBase<Urun, int>
    {
        public override void Update(Urun entity, bool isSaveLater = false)
        {
            var entry = _context.Entry(entity);
            var eskiFiyat = (decimal)entry.OriginalValues["Fiyat"];
            //urun fiyat gecmisi tablosuna eklenir/loglanir
            base.Update(entity, isSaveLater);
        }
    }
}
