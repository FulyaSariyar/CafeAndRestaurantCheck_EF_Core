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
            FrmKurulum frmKurulum = new FrmKurulum();
            frmKurulum.Show();
            this.Hide();
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {
            this.dgViewGunluk.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgViewAylik.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        int sumAylik = 0;
        private void btnAylikRapor_Click(object sender, EventArgs e)
        {
          
            dgViewAylik.DataSource = _siparisRepo.Aylik();

            foreach (RaporViewModel item in _siparisRepo.Aylik())
            {
                if (item.CreatedDate.HasValue && item.CreatedDate.Value.Date >= DateTime.Now.AddMonths(-1)
                         && (item.CreatedDate.HasValue && item.CreatedDate.Value.Date <= DateTime.Now.Date))
                {             
                      sumAylik+= Convert.ToInt32(item.AraToplam);
                }
            }

            lblAylikToplam.Text = $"AYLIK CİRO : {sumAylik} ₺";
        }
        int sumGunluk = 0;
        private void btnGünlükRapor_Click_1(object sender, EventArgs e)
        {

           
           
            dgViewGunluk.DataSource = _siparisRepo.Gunluk();
            foreach (RaporViewModel item in _siparisRepo.Gunluk())
            {
                if (item.CreatedDate.HasValue && item.CreatedDate.Value.Date == DateTime.Now.Date)
                {
                    sumGunluk += Convert.ToInt32(item.AraToplam);
                }
            }

            lblGunlukToplam.Text = $"GÜNLÜK CİRO : {sumGunluk} ₺";



        }

       
    }
}
