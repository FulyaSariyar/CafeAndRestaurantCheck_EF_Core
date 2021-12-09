using CafeAndRestaurantCheck_EF_Core.Data;
using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CafeAndRestaurantCheck_EF_Core.Forms
{
    public partial class FrmKurulum : Form
    {
        private CafeContext _dbContext = new CafeContext();
        private UrunRepo _urunRepo = new UrunRepo();
        private KategoriRepo _kategoriRepo = new KategoriRepo();
        public FrmKurulum()
        {
            InitializeComponent();          
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            var urun = new Urun();
            try
            {
                urun.Ad = txtUrunAd.Text;
                urun.BirimFiyat = Convert.ToDecimal(txtFiyat.Text);

                if (pbResim.Image != null)
                {
                    MemoryStream resimStream = new MemoryStream();
                    pbResim.Image.Save(resimStream, ImageFormat.Jpeg);
                    urun.Fotograf = resimStream.ToArray();
                }

                
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            if (pbResim.Image != null)
            {
                MemoryStream resimStream = new MemoryStream();
                pbResim.Image.Save(resimStream, ImageFormat.Jpeg);

                urun.Fotograf = resimStream.ToArray();
            }
            _urunRepo.Add(urun);
           
        }

        private void pbResim_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "Bir fotoğraf seçiniz";
            dialog.Filter = "Resim Dosyaları | *.jpeg; *.jpg; *.png; *.jfif";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbResim.ImageLocation = dialog.FileName;
            }
        }


        private Urun seciliUrun;
        private Kategori seciliKategori;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (seciliUrun == null) return;

            if (cmbKategori.SelectedItem != null)
            {
                seciliKategori = (Kategori)cmbKategori.SelectedItem;
            }
            else
            {
                seciliKategori = null;
            }
            try
            {
                var urun = _dbContext.Urunler.First(x => x.Id == seciliUrun.Id);

                urun.Ad = txtUrunAd.Text;
                urun.BirimFiyat = Convert.ToDecimal(txtFiyat.Text);
                urun.KategoriId = seciliUrun.Id;

                _urunRepo.Update(urun);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                _dbContext = new CafeContext();
            }
            
        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            var kategori = new Kategori();
            try
            {
                kategori.Ad = txtKategoriAd.Text;
                kategori.Aciklama = txtAciklama.Text;


                if (pbKategori.Image != null)
                {
                    MemoryStream resimStream = new MemoryStream();
                    pbKategori.Image.Save(resimStream, ImageFormat.Jpeg);
                    kategori.Fotograf = resimStream.ToArray();
                }

                _kategoriRepo.Add(kategori);
                ListeleKategori();
               

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if (pbKategori.Image != null)
            {
                MemoryStream resimStream = new MemoryStream();
                pbKategori.Image.Save(resimStream, ImageFormat.Jpeg);

                kategori.Fotograf = resimStream.ToArray();
            }
            

        }

        private void pbKategori_Click(object sender, EventArgs e)
        {

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "Bir fotoğraf seçiniz";
            dialog.Filter = "Resim Dosyaları | *.jpeg; *.jpg; *.png; *.jfif";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbKategori.ImageLocation = dialog.FileName;
            }
        }

        private void ListeleKategori()
        {
            dgViewKategori.DataSource = null;
            dgViewKategori.DataSource = _kategoriRepo.GetAll().Where(x => x.IsDeleted == false).ToList();
        }
        private void btnKategoriSil_Click(object sender, EventArgs e)
        {
            var seciliKategori = (Kategori)this.dgViewKategori.CurrentRow.DataBoundItem;
            var kategori = _kategoriRepo.GetAll().FirstOrDefault(x => x.Id == seciliKategori.Id) as Kategori;
            //var kategori = _kategoriRepo.GetById(seciliKategori.Id) as Kategori;
            _kategoriRepo.Remove(kategori);
            ListeleKategori();
           



        }

        private void btnKategoriListele_Click(object sender, EventArgs e)
        {
            dgViewKategori.DataSource = _kategoriRepo.GetAll().ToList();
        }

        private void btnBinaKurulum_Click(object sender, EventArgs e)
        {
            FrmBinaBilgileri frmBinaBilgileri =new FrmBinaBilgileri();
            frmBinaBilgileri.Show();

        }


        private void btnKategoriGuncelle_Click_1(object sender, EventArgs e)
        {
            var seciliKategori = (Kategori)this.dgViewKategori.CurrentRow.DataBoundItem;
            var kategori = _kategoriRepo.GetById(seciliKategori.Id) as Kategori;
            seciliKategori.Ad = txtKategoriAd.Text;
            seciliKategori.Aciklama = txtAciklama.Text;
            seciliKategori.Fotograf = (byte[])new ImageConverter().ConvertTo(pbKategori.Image, typeof(byte[]));
            _kategoriRepo.Update(kategori);
            ListeleKategori();



        }

        
    }
}




