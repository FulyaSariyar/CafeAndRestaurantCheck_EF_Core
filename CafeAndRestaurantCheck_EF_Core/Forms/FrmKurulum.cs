using CafeAndRestaurantCheck_EF_Core.Data;
using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Repository;
using Microsoft.EntityFrameworkCore;
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

        private void FrmKurulum_Load(object sender, EventArgs e)
        {
            cmbKategori.DataSource = _kategoriRepo.GetAll().ToList();
            cmbKategori.DisplayMember = "Ad";
        }
        public FrmKurulum()
        {
            InitializeComponent();
        }

        private void UrunListele()
        {
            lstUrunler.DataSource = null;
            lstUrunler.DataSource = _urunRepo.GetAll().Where(x => x.IsDeleted == false).ToList();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {

            if (cmbKategori.SelectedItem != null)
            {
                seciliKategori = (Kategori)cmbKategori.SelectedItem;
            }
            else
            {
                seciliKategori = null;
            }
            var urun = new Urun();
            try
            {
                urun.Ad = txtUrunAd.Text;
                urun.BirimFiyat = Convert.ToDecimal(txtFiyat.Text);
                urun.KategoriId = seciliKategori.Id;

                if (pbUrun.Image != null)
                {
                    MemoryStream resimStream = new MemoryStream();
                    pbUrun.Image.Save(resimStream, ImageFormat.Jpeg);
                    urun.Fotograf = resimStream.ToArray();
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Bir hata oluştu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            if (pbUrun.Image != null)
            {
                MemoryStream resimStream = new MemoryStream();
                pbUrun.Image.Save(resimStream, ImageFormat.Jpeg);

                urun.Fotograf = resimStream.ToArray();
            }
            _urunRepo.Add(urun);
            UrunListele();
        }

        private void pbUrun_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Title = "Bir fotoğraf seçiniz";
            dialog.Filter = "Resim Dosyaları | *.jpeg; *.jpg; *.png; *.jfif";
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            DialogResult result = dialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                pbUrun.ImageLocation = dialog.FileName;
            }

        }
        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstUrunler.SelectedItem == null) return; //index çaıştığında null gelebilir. Hata verme.

            // seciliUrun = lstUrunler.SelectedItem as Urun;
            Urun seciliUrun = (Urun)lstUrunler.SelectedItem;
            txtUrunAd.Text = seciliUrun.Ad;
            txtFiyat.Text = seciliUrun.BirimFiyat.ToString();
            cmbKategori.SelectedItem = seciliUrun.Kategori;

            if (seciliUrun.Fotograf != null)
            {
                MemoryStream stream = new MemoryStream(seciliUrun.Fotograf);
                pbUrun.Image = Image.FromStream(stream);
            }
        }

        private Urun seciliUrun;
        private Kategori seciliKategori;
        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbKategori.Text))
            {
                MessageBox.Show("Kategori alanı boş geçilemez.");
                return;                
            }

            Urun seciliUrun = (Urun)lstUrunler.SelectedItem;

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
                //var urun = _urunRepo.GetAll().First(x => x.Id == seciliUrun.Id);
                var urun = _urunRepo.GetById(seciliUrun.Id);

                urun.Ad = txtUrunAd.Text;
                urun.BirimFiyat = Convert.ToDecimal(txtFiyat.Text);
                urun.KategoriId = seciliKategori.Id;

                if (pbUrun.Image != null)
                {
                    MemoryStream resimStream = new MemoryStream();
                    pbUrun.Image.Save(resimStream, ImageFormat.Jpeg);

                    urun.Fotograf = resimStream.ToArray();
                }

                _urunRepo.Update(urun);
            }
            catch (Exception ex)
            {
                MessageBox.Show("KAtegori boş geçilemez.");
                _dbContext = new CafeContext();
            }
            finally
            {
                UrunListele();
            }
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            UrunListele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Urun seciliUrun = (Urun)lstUrunler.SelectedItem;

            if (seciliUrun == null) return;

            DialogResult cevap = MessageBox.Show($"{seciliUrun} yi silmek istiyor musunuz?", "Silme onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                try
                {
                    _urunRepo.Remove(seciliUrun);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    _dbContext = new CafeContext();
                }
                finally
                {
                    UrunListele();
                }
            }

           
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
            var seciliKategori = new Kategori();
            if (seciliKategori == null) return;
            seciliKategori = (Kategori)this.dgViewKategori.CurrentRow.DataBoundItem;
            var kategori = _kategoriRepo.GetAll().FirstOrDefault(x => x.Id == seciliKategori.Id) as Kategori;
            DialogResult cevap = MessageBox.Show($"{seciliKategori.Ad} yi silmek istiyor musunuz?", "Silme onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                _kategoriRepo.Remove(kategori);
                ListeleKategori();
            }
            //var kategori = _kategoriRepo.GetById(seciliKategori.Id) as Kategori;


        }

        private void btnKategoriListele_Click(object sender, EventArgs e)
        {
            dgViewKategori.DataSource = _kategoriRepo.GetAll().ToList();
        }

        private void btnBinaKurulum_Click(object sender, EventArgs e)
        {
            FrmBinaBilgileri frmBinaBilgileri = new FrmBinaBilgileri();
            frmBinaBilgileri.Show();

        }


        private void btnKategoriGuncelle_Click_1(object sender, EventArgs e)
        {
            var seciliKategori = new Kategori();
            if (seciliKategori == null) return;
            seciliKategori = (Kategori)this.dgViewKategori.CurrentRow.DataBoundItem;
            var kategori = _kategoriRepo.GetById(seciliKategori.Id) as Kategori;
            seciliKategori.Ad = txtKategoriAd.Text;
            seciliKategori.Aciklama = txtAciklama.Text;
            seciliKategori.Fotograf = (byte[])new ImageConverter().ConvertTo(pbKategori.Image, typeof(byte[]));


            _kategoriRepo.Update(kategori);
            ListeleKategori();



        }



        private void dgViewKategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            seciliKategori = (Kategori)this.dgViewKategori.CurrentRow.DataBoundItem;
            txtKategoriAd.Text = seciliKategori.Ad;
            txtAciklama.Text = seciliKategori.Aciklama;
            if (seciliKategori.Fotograf != null)
            {
                MemoryStream stream = new MemoryStream(seciliKategori.Fotograf);
                pbKategori.Image = Image.FromStream(stream);

            }
        }

        private void txtKategoriAd_KeyPress(object sender, KeyPressEventArgs e)
        {


           //if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ' '))
           // {
           //     e.Handled = true;
           // }



        }
    }
}




