using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeAndRestaurantCheck_EF_Core.Models
{
    [Table(name: "BinaBilgileri")]
    public  class BinaBilgi
    {
        [Key]
        public int Id { get; set; }
        [Required,StringLength(20)]
        public string BinaBolumAdi { get; set; }
        [Required]
        public byte MasaAdet { get; set; }
    }
}
