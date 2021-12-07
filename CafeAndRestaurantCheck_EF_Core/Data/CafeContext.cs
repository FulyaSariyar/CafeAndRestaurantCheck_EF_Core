using CafeAndRestaurantCheck_EF_Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Data
{
    public class CafeContext :DbContext
    {
        public CafeContext()
           : base()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer( @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = CafeDb; Integrated Security = True;");
            }
        }


        public DbSet<BinaBilgi> BinaBilgileri { get; set; }
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Urun>()
                .Property(x => x.BirimFiyat)
                .HasPrecision(10, 2);//hassasiyet

            modelBuilder.Entity<Siparis>()
                .Property(x => x.BirimFiyat)
                .HasPrecision(10, 2);//hassasiyet

            modelBuilder.Entity<Siparis>()
                .Property(x => x.AraToplam)
                .HasPrecision(10, 2);//hassasiyet



        }
    }
}
