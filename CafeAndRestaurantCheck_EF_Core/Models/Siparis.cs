using CafeAndRestaurantCheck_EF_Core.Models.Abstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Models
{
    [Table(name: "Siparisler")]
    public class Siparis: BaseEntity, IKey<int>
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(50)]
        public Urun Urun { get; set; }
        public int Adet { get; set; } = 1;
        [Required]// fluent api de hassasiyet ver
        public decimal BirimFiyat { get; set; }

        [Required, StringLength(50)]
        public string MasaAd { get; set; }

        [Required]
        public bool MasaDurum { get; set; } = false;
        [Required]// fluent api de hassasiyet ver
        //public decimal AraToplam { get => Adet * BirimFiyat; set; } 
        public decimal AraToplam { get; set; }
    }
}
