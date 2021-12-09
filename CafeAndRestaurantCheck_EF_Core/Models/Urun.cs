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
    [Table(name: "Urunler")]
    public partial class Urun : BaseEntity, IKey<int>
    {
        [Key]
        public int Id { get; set; }
        [Required, StringLength(50)]
        public string Ad { get; set; }
        [Required]
        public decimal BirimFiyat { get; set; } = 0;
        public int KategoriId { get; set; }
        public byte[] Fotograf { get; set; }

        [ForeignKey(nameof(KategoriId))]
        public Kategori Kategori { get; set; }
       


    }
}
