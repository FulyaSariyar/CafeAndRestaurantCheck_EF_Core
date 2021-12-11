using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Repository;
using CafeAndRestaurantCheck_EF_Core.ViewModels;
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
    public partial class FrmRapor : Form
    {
        private SiparisRepo _siparisRepo = new SiparisRepo();
        public FrmRapor()
        {
            InitializeComponent();
        }

        private void btnRaporGeri_Click_1(object sender, EventArgs e)
        {
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Show();
            this.Hide();
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            this.dgViewGunluk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgViewAylik.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }


        private void btnAylikRapor_Click(object sender, EventArgs e)
        {
            var siparis = new Siparis();
            _siparisRepo.Aylik(siparis);
            dgViewAylik.DataSource = _siparisRepo.GetAll().ToList();
        }

        private void btnGünlükRapor_Click_1(object sender, EventArgs e)
        {

            var siparis = new Siparis();
            //_siparisRepo.Gunluk(siparis);
            dgViewGunluk.DataSource = _siparisRepo.Gunluk();
            

        }
    }
}
