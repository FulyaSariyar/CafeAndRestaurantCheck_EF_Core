using CafeAndRestaurantCheck_EF_Core.Data;
using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Repository.Abstracts;
using CafeAndRestaurantCheck_EF_Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Repository
{
   
    internal class SiparisRepo : RepositoryBase<Siparis, int>
    {
        // private  CafeContext _context = new CafeContext();

        public virtual List<RaporViewModel> Gunluk()
        {
            var query1 = from siparis in _context.Siparisler
                         join urun in _context.Urunler on siparis.Id equals urun.Id
                         where siparis.CreatedDate.HasValue && siparis.CreatedDate.Value.Date == DateTime.Now.Date
                         select new RaporViewModel
                         {
                             Ad = urun.Ad,
                             CreatedDate = siparis.CreatedDate,
                             BirimFiyat = siparis.BirimFiyat,
                             Adet = siparis.Adet,
                             AraToplam = siparis.AraToplam
                         };
            return query1.ToList();
        }
        public virtual List<RaporViewModel> Aylik()
        {

            var query2 = from siparis in _context.Siparisler
                         join urun in _context.Urunler on siparis.Id equals urun.Id
                         where (siparis.CreatedDate.HasValue && siparis.CreatedDate.Value.Date >= DateTime.Now.AddDays(30)) || (siparis.CreatedDate.HasValue && siparis.CreatedDate.Value.Date == DateTime.Now.Date)
                         select new  RaporViewModel
                         {

                             Ad = urun.Ad,
                             CreatedDate = siparis.CreatedDate,
                             BirimFiyat = siparis.BirimFiyat,
                             Adet = siparis.Adet,
                             AraToplam = siparis.AraToplam

                         };
            return query2.ToList();
        }

        public virtual List<SepetViewModel> MasaSiparisleriSepet(Button masaAd)
        {
            return _context.Siparisler
                .Include(s => s.Urun)
                .Where(s => s.MasaAd == masaAd.Name && s.IsDeleted == false)
                //.Where(s => s.MasaAd == masaAd.Name && s.MasaDurum == true)
                .Select(s => new SepetViewModel
                {
                    Urun = s.Urun,
                    Adet = s.Adet,
                })
               .ToList();
        }
        public virtual List<Siparis> MasaSiparisleri(Button masaAd)
        {
            return _context.Siparisler
               //.Include(s => s.Urun)
               .Where(s => s.MasaAd == masaAd.Name && s.IsDeleted==false)
               //.Select s 
              .ToList();
        }

            //public override void Remove(Siparis entity, bool isSaveLater = false)
            //{
            //    var ıd = _context.Entry(entity);
            //    var eskiFiyat = (decimal)entry.OriginalValues["Fiyat"];
            //    //urun fiyat gecmisi tablosuna eklenir/loglanir
            //    base.Update(entity, isSaveLater);
            //}
        }
}

