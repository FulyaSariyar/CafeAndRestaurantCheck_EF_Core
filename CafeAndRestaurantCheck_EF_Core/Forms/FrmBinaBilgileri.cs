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
    public partial class FrmBinaBilgileri : Form
    {
        private BinaRepo _binaRepo = new BinaRepo();
        public FrmBinaBilgileri()
        {
            InitializeComponent();
            for (int i = 1; i <= 20; i++)
            {
                cbBahçe.Items.Add(i);
                cbZemin.Items.Add(i);
                cbKat1.Items.Add(i);
                cbKat2.Items.Add(i);
                cbKat3.Items.Add(i);
                cbKat4.Items.Add(i);
                cbTeras.Items.Add(i);
            }
        }

        private void FrmBinaBilgileri_Load(object sender, EventArgs e)
        {

        }
        List<string> katMasa = new List<string>();
        List<string> katAd = new List<string>();

        private void btnEkle_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < checkedListBox1.CheckedItems.Count; i++)
            {
                string bilgi = checkedListBox1.CheckedItems[i].ToString();
                katAd.Add(bilgi);
            }

            foreach (Control control in pnlCombolar.Controls)
            {
                if (control is ComboBox && control.Text != "")
                    katMasa.Add(control.Text);
            }
            katMasa.Reverse();

            for (int i = 0; i < katAd.Count; i++)
            {
                var bina = new BinaBilgi()
                {
                    BinaBolumAdi = katAd[i],
                    MasaAdet = katMasa[i]
                };
               
                _binaRepo.Add(bina);
            };
            MessageBox.Show("fdgdfg");


        }

      
     

        private void btnListele_Click(object sender, EventArgs e)
        {
            dtgrdBinaBilgileri.DataSource= _binaRepo.GetAll().ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var bina = dtgrdBinaBilgileri.SelectedRows[0];
            // _binaRepo.Remove(bina);
            Console.WriteLine();

        }

        
    }
}
