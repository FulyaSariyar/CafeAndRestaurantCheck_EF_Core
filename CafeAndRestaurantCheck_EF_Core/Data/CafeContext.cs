using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Models.Abstracts;
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
                optionsBuilder.UseSqlServer( @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = CafeDb1; Integrated Security = True;");
            }
            //DbContext.Entry<Urun>(urun).State = Microsoft.EntityFrameworkCore.EntityState.Modified
        }




        public DbSet<BinaBilgi> BinaBilgileri { get; set; }
        
        public DbSet<Urun> Urunler { get; set; }
        public DbSet<Siparis> Siparisler { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }


        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && x.State == EntityState.Added);

            foreach (var item in entries)
            {
                ((BaseEntity)item.Entity as BaseEntity).CreatedDate = DateTime.Now;
            }

            entries = ChangeTracker.Entries()
                .Where(x => x.Entity is BaseEntity && x.State == EntityState.Modified);
            foreach (var item in entries)
            {
                ((BaseEntity)item.Entity as BaseEntity).UpdatedDate = DateTime.Now;
            }

            entries = ChangeTracker.Entries()
               .Where(x => x.Entity is BaseEntity && x.State == EntityState.Deleted);
            foreach (var item in entries)
            {
                ((BaseEntity)item.Entity as BaseEntity).DeletedDate = DateTime.Now;
                ((BaseEntity)item.Entity).IsDeleted = true;
                item.State = EntityState.Modified;
            }

            return base.SaveChanges();
        }
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

         public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries() //neyin nasıl değiştriğini tutar
                  .Where(x => x.Entity is BaseEntity && x.State == EntityState.Added);

            foreach (var item in entries)
            {
                ((BaseEntity)item.Entity).CreatedDate = DateTime.Now;
            }


            entries = ChangeTracker.Entries() 
                  .Where(x => x.Entity is BaseEntity && x.State == EntityState.Modified);

            foreach (var item in entries)
            {
                ((BaseEntity)item.Entity).UpdatedDate = DateTime.Now;
            }


            entries = ChangeTracker.Entries()
                  .Where(x => x.Entity is BaseEntity && x.State == EntityState.Deleted);

            foreach (var item in entries)
            {
                ((BaseEntity)item.Entity).DeletedDate = DateTime.Now;
                ((BaseEntity)item.Entity).IsDeleted= true;
                item.State= EntityState.Modified;
            }
            return base.SaveChanges();
          
        }
    }
}
