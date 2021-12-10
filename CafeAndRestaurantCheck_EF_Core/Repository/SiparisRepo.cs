using CafeAndRestaurantCheck_EF_Core.Data;
using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Repository.Abstracts;
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

        public virtual void Gunluk(Siparis entity)
        {
            var query1 = from siparis in _context.Siparisler
                         join urun in _context.Urunler on siparis.Id equals urun.Id
                         where siparis.CreatedDate == DateTime.Today
                         select new
                         {

                             urun.Ad,
                             siparis.CreatedDate,
                             siparis.BirimFiyat,
                             siparis.Adet,
                             siparis.AraToplam
                         };
        }
        public virtual void Aylik(Siparis entity)
        {

            var query2 = from siparis in _context.Siparisler
                         join urun in _context.Urunler on siparis.Id equals urun.Id
                         where siparis.CreatedDate >= Convert.ToDateTime(DateTime.Now.AddMonths(-1).ToShortDateString()) && siparis.CreatedDate <= Convert.ToDateTime(DateTime.Now.ToShortDateString())
                         select new
                         {

                             urun.Ad,
                             siparis.CreatedDate,
                             siparis.BirimFiyat,
                             siparis.Adet,
                             siparis.AraToplam
                         };
        }
        }
    }

