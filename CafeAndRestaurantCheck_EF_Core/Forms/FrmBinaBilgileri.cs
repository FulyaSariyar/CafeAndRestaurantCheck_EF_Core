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
    public partial class FrmBinaBilgileri : Form
    {
        private BinaRepo _binaRepo = new BinaRepo();
        private CafeContext _cafeContext = new CafeContext();
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
            //List<BinaBilgi> list=new List<BinaBilgi>();
            ////var value = (chkListCategory.CheckedItems[0] as ListItem).Value;
            //list = _binaRepo.GetAll().ToList();
            //for (int i = 1; i < _cafeContext.BinaBilgileri.Count(); i++)
            //{
            //    if (checkedListBox1.Items(checkedListBox1.SelectedItem.ToString()) == list[i].BinaBolumAdi)
            //        checkedListBox1.SetItemChecked(i, true);
            //}

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
            Listele();
        }

        private void Listele()
        {
            dtgrdBinaBilgileri.DataSource = null;
            dtgrdBinaBilgileri.DataSource = _binaRepo.GetAll().Where(x=>x.IsDeleted == false).ToList();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            var secilibina = (BinaBilgi)this.dtgrdBinaBilgileri.CurrentRow.DataBoundItem;

            //var secilibina = dtgrdBinaBilgileri.SelectedRows[0] as BinaBilgi;
            //var bina = _cafeContext.B8inaBilgileri.Find0(secilibina.Id) 00 as BinaBilgi;
            var bina = _binaRepo.GetAll().FirstOrDefault(x=>x.Id == secilibina.Id) as BinaBilgi;
            //var bina = _cafeContext.BinaBilgileri.First(x => x.Id == secilibina.Id) as BinaBilgi;
            _binaRepo.Remove(bina);
            Listele();

        }
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            var secilibina = (BinaBilgi)this.dtgrdBinaBilgileri.CurrentRow.DataBoundItem;
            var bina = _binaRepo.GetById(secilibina.Id) as BinaBilgi;
            if (secilibina.BinaBolumAdi == "Bahçe"&& secilibina.BinaBolumAdi=="Bahçe")
                bina.MasaAdet = cbBahçe.Text;
            else if (secilibina.BinaBolumAdi == "Zemin Kat"&& secilibina.BinaBolumAdi == "Zemin Kat")
                bina.MasaAdet = cbZemin.Text;
            else if (secilibina.BinaBolumAdi == "Kat 1" && secilibina.BinaBolumAdi == "Kat 1")
                bina.MasaAdet = cbKat1.Text;
            else if (secilibina.BinaBolumAdi == "Kat 2" && secilibina.BinaBolumAdi == "Kat 2")
                bina.MasaAdet = cbKat2.Text;
            else if (secilibina.BinaBolumAdi == "Kat 3" && secilibina.BinaBolumAdi == "Kat 3")
                bina.MasaAdet = cbKat3.Text;
            else if (secilibina.BinaBolumAdi == "Kat 4" && secilibina.BinaBolumAdi == "Kat 4")
                bina.MasaAdet =cbKat3.Text;
            else if (secilibina.BinaBolumAdi == "Teras" && secilibina.BinaBolumAdi == "Teras")
                bina.MasaAdet = cbTeras.Text;
            _binaRepo.Update(bina);
            Listele();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
