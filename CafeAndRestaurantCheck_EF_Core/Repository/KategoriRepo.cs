using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Repository.Abstracts;
using CafeAndRestaurantCheck_EF_Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Repository
{
    internal  class KategoriRepo: RepositoryBase<Kategori, int>
    {
       public virtual List<KategoriViewModel> KategoriListele()
        {
            var query1 = _context.Kategoriler
                .Select(x => new KategoriViewModel()
                {
                    Ad = x.Ad,
                    Aciklama = x.Aciklama,
                    Fotograf = x.Fotograf,
                });
            return query1.ToList();
        }
    }
}
