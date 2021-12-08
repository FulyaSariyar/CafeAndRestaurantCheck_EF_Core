using CafeAndRestaurantCheck_EF_Core.Data;
using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeAndRestaurantCheck_EF_Core.Forms
{
    public partial class FrmKurulum : Form
    {
        private KategoriRepo _kategoriRepo = new KategoriRepo();
        public FrmKurulum()
        {
            InitializeComponent();
        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            var kategori = new Kategori
            {
                Ad = "Kategori",
                Aciklama = "açıklama",
                Fotograf=

            };
            _kategoriRepo.Add(kategori);
        }
    }
}
