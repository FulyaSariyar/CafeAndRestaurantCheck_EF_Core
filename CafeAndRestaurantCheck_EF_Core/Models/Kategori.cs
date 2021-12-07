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
    [Table("Kategoriler")]
    public class Kategori : BaseEntity, IKey<int>
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Ad alanı boş geçilemez")]
        [StringLength(30, ErrorMessage = "Ad alanı en fazla 30 karekter olabilir.")]
        public string Ad { get; set; }
        [StringLength(200)]
        public string? Aciklama { get; set; }


        //public ICollection<Urun> Urunler { get; set; } = new HashSet<Urun>();
    }
}
