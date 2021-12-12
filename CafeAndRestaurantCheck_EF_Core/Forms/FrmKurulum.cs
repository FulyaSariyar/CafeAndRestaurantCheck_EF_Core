using CafeAndRestaurantCheck_EF_Core.Data;
using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Repository;
using CafeAndRestaurantCheck_EF_Core.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.Data;

using System.Drawing.Imaging;

namespace CafeAndRestaurantCheck_EF_Core.Forms
{
    public partial class FrmKurulum : Form
    {
        private CafeContext _dbContext = new CafeContext();
        private UrunRepo _urunRepo = new UrunRepo();
        private KategoriRepo _kategoriRepo = new KategoriRepo();

        private void FrmKurulum_Load(object sender, EventArgs e)
        {

            UrunListele();
            this.dgViewKategori.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            UrunListele();   

        }
        public FrmKurulum()
        {
            InitializeComponent();
        }

        private void UrunListele()
        {
            lstUrunler.DataSource = null;
            lstUrunler.DataSource = _urunRepo.GetAll().Where(x => x.IsDeleted == false).ToList();

            cmbKategori.DataSource = _dbContext.Kategoriler.Where(x => x.IsDeleted == false).ToList();
            cmbKategori.DisplayMember = "Ad";
            cmbKategori.ValueMember = "Id";

            lstUrunler.DataSource = _dbContext.Urunler
               .Include(x => x.Kategori).Where(x => x.IsDeleted == false).ToList();
        }
        private void btnKaydet_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Ürün eklemek istiyor musunuz?", "Ürün Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
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
                _urunRepo.Add(urun);
                UrunListele();
                MessageBox.Show("Ürün Ekleme işlemi Tamamlandı");
            }
            else
            {
                MessageBox.Show("Ürün Ekleme işlemi Yapılmadı");

            }
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
        private Urun seciliUrun;
        private void lstUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (lstUrunler.SelectedItem == null) return; //index çaıştığında null gelebilir. Hata verme.
          
            // seciliUrun = lstUrunler.SelectedItem as Urun;
            seciliUrun = (Urun)lstUrunler.SelectedItem;
            txtUrunAd.Text = seciliUrun.Ad;
            txtFiyat.Text = seciliUrun.BirimFiyat.ToString();
            cmbKategori.SelectedItem = seciliUrun.Kategori;

            if (seciliUrun.Fotograf != null)
            {
                MemoryStream stream = new MemoryStream(seciliUrun.Fotograf);
                pbUrun.Image = Image.FromStream(stream);
            }
        }
        
        private Kategori seciliKategori;
        private KategoriViewModel _seciliKategoriViewModel;
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
                DialogResult result = MessageBox.Show("Seçili ürününü güncellemek istiyor musunuz?", "Ürün Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
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
                else
                {
                    MessageBox.Show("Ürün Güncelleme İşlemi Yapılmadı");

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Kategori boş geçilemez.");
                _dbContext = new CafeContext();
            }
            finally
            {
                UrunListele();
                MessageBox.Show("Ürün Güncelleme İşlemi Yapıldı");
            }

            _dbContext = new CafeContext();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            UrunListele();
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            Urun seciliUrun = (Urun)lstUrunler.SelectedItem;

            if (seciliUrun == null) return;

            DialogResult cevap = MessageBox.Show("Seçili ürünü silmek istiyor musunuz?", "Silme onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (cevap == DialogResult.Yes)
            {
                try
                {
                    _urunRepo.Remove(seciliUrun);
                    MessageBox.Show("Ürün silme işlemi tamamlandı");
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
            else
            {
                MessageBox.Show("Ürün silme işlemi yapılmadı");

            }
            _dbContext = new CafeContext();
        }

        private void btnKategoriEkle_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Kategori eklemek istiyor musunuz?", "Kategori Ekleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
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
                    _kategoriRepo.KategoriListele();
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

                MessageBox.Show("Kategori Ekleme İşlemi Tamamlandı");
            }
            else
            {
                MessageBox.Show("Kategori Ekleme İşlemi Yapılmadı");
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
        private void btnKategoriSil_Click(object sender, EventArgs e)
        {
           
                if (_seciliKategoriViewModel == null) return;
                _seciliKategoriViewModel = (KategoriViewModel)this.dgViewKategori.CurrentRow.DataBoundItem;
                var kategori = _kategoriRepo.GetAll().FirstOrDefault(x => x.Id == _seciliKategoriViewModel.Id) as Kategori;

            DialogResult cevap = MessageBox.Show($"{_seciliKategoriViewModel.Ad} yi silmek istiyor musunuz?", "Silme onayı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                _kategoriRepo.Remove(kategori);
                    _kategoriRepo.KategoriListele();
                //var kategori = _kategoriRepo.GetById(seciliKategori.Id) as Kategori;
                MessageBox.Show("Kategori Silme İşlemi Tamamlandı");
            }
            else
            {
                MessageBox.Show("Kategori Silme İşlemi Yapılmadı");
            }

        }

        private void btnKategoriListele_Click(object sender, EventArgs e)
        {
            dgViewKategori.DataSource = null;
            dgViewKategori.DataSource = _kategoriRepo.KategoriListele();
        }

        private void btnBinaKurulum_Click(object sender, EventArgs e)
        {
            FrmBinaBilgileri frmBinaBilgileri = new FrmBinaBilgileri();
            frmBinaBilgileri.Show();

        }
        private void btnKategoriGuncelle_Click_1(object sender, EventArgs e)
        {
           
                var seciliKategori = new Kategori();
                if (_seciliKategoriViewModel == null) return;
                _seciliKategoriViewModel = (KategoriViewModel)this.dgViewKategori.CurrentRow.DataBoundItem;
                var kategori = _kategoriRepo.GetById(_seciliKategoriViewModel.Id) as Kategori;
                _seciliKategoriViewModel.Ad = txtKategoriAd.Text;
                _seciliKategoriViewModel.Aciklama = txtAciklama.Text;
                _seciliKategoriViewModel.Fotograf = (byte[])new ImageConverter().ConvertTo(pbKategori.Image, typeof(byte[]));

            DialogResult result = MessageBox.Show("Seçili kategoriyi güncellemek istiyor musunuz?", "Kategori Güncelleme", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                _kategoriRepo.Update(kategori);
                _kategoriRepo.KategoriListele();

                MessageBox.Show("Kategori Güncelleme İşlemi Tamamlandı");
            }
            else
            {
                MessageBox.Show("Kategori Güncelleme İşlemi Yapılmadı");
            }

        }
        private void dgViewKategori_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            _seciliKategoriViewModel = (KategoriViewModel)dgViewKategori.CurrentRow.DataBoundItem;
            txtKategoriAd.Text = _seciliKategoriViewModel.Ad;
            txtAciklama.Text = _seciliKategoriViewModel.Aciklama;
            if (_seciliKategoriViewModel.Fotograf != null)
            {
                MemoryStream stream = new MemoryStream(_seciliKategoriViewModel.Fotograf);
                pbKategori.Image = Image.FromStream(stream);

            }
        }

        private void txtKategoriAd_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtUrunAd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsLetter(e.KeyChar) == false) && (e.KeyChar != (char)08))
            {
                e.Handled = true;
            }
        }        

        private void txtFiyat_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((char.IsDigit(e.KeyChar) == false) && (e.KeyChar != (char)08))
            {
                e.Handled = true;
            }
        }

        private void btnRaporlar_Click(object sender, EventArgs e)
        {
            FrmRapor frmRapor = new FrmRapor();
            frmRapor.Show();
            this.Hide();
        }

        private void btnKur_Click(object sender, EventArgs e)
        {
           FrmPersonel frmPersonel = new FrmPersonel();
            frmPersonel.Show();
            this.Hide();
        }

        
    }
}




