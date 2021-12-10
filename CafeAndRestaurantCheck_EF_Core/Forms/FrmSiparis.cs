using CafeAndRestaurantCheck_EF_Core.Data;
using CafeAndRestaurantCheck_EF_Core.Models;
using CafeAndRestaurantCheck_EF_Core.Repository;
using CafeAndRestaurantCheck_EF_Core.ViewModels;
using Microsoft.EntityFrameworkCore;
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
    public partial class FrmSiparis : Form
    {
        private CafeContext _dbContext = new CafeContext();
        private KategoriRepo _kategoriRepo = new KategoriRepo();
        private SiparisRepo _siparisRepo = new SiparisRepo();
        private UrunRepo _urunRepo = new UrunRepo();
        Button _oMasa;
        public FrmSiparis(Button oMasa)
        {
            InitializeComponent();
            _oMasa = oMasa;
        }


        // * Load kısmında sipariş form pictureboxlara çekme işlemi gerçekleştirildi.

        private void FrmSiparis_Load(object sender, EventArgs e)
        {

            var kategoriler = _kategoriRepo.GetAll().ToList();

            for (int i = 0; i < kategoriler.Count(); i++)
            {
                var groupBox = new GroupBox();
                groupBox.Name = $"grpBox{kategoriler[i].Ad}";
                MemoryStream stream = new MemoryStream(kategoriler[i].Fotograf);
                var pbox = new PictureBox
                {
                    SizeMode = PictureBoxSizeMode.StretchImage,
                    Size = new Size(320, 210),
                    Image = Image.FromStream(stream)
                };
                pbox.Name = $"{kategoriler[i].Ad}";
                pbox.Click += new EventHandler(pbox_Click);
                pbox.Parent = groupBox;
                flwpMenu.Controls.Add(pbox);

                //Label içerisinde menü isimleri yazdırıldı
                Label lblDetay = new Label
                {
                    Text = $"{kategoriler[i].Ad}",
                    ForeColor = Color.Chocolate,
                    Font = new Font("Arial", 10, FontStyle.Bold),
                    BackColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Location = new Point(7, 7)
                };
                lblDetay.Parent = pbox;
            }

            _sepet = _dbContext.Siparisler
                .Include(s => s.Urun)
                .Where(s => s.MasaAd == _oMasa.Name && s.MasaDurum == true)
                .Select(s => new SepetViewModel
                { 
                    Urun = s.Urun,
                    Adet = s.Adet,
                })
               .ToList();
            SepetiDoldur();
            Console.WriteLine();
        }

        //* Tıklanan menüye göre ürüler getirildi.
        private void pbox_Click(object sender, EventArgs e)
        {
            var query = _dbContext.Kategoriler
                .Include(x => x.Urunler).ToList();
            flwpUrunller.Controls.Clear();
            PictureBox oPictureBox = (PictureBox)sender;
            foreach (var item in query)
            {
                if (oPictureBox.Name == item.Ad)
                {
                    foreach (var eleman in item.Urunler)
                    {
                        MemoryStream stream = new MemoryStream(eleman.Fotograf);
                        var groupBox = new GroupBox();
                        groupBox.Name = $"grpBox{eleman.Ad}";

                        //Sol taraf menü listesi click olaylaarı
                        var pbox = new PictureBox
                        {
                            SizeMode = PictureBoxSizeMode.StretchImage,
                            Size = new Size(210, 160),
                            Image = Image.FromStream(stream)
                        };

                        pbox.Name = $"{eleman.Ad}";
                        pbox.Click += new EventHandler(pboxUrunler_Click);
                        pbox.Parent = groupBox;
                        flwpUrunller.Controls.Add(pbox);

                        // Label içerisinde ürün bilgileri yazdırıldı
                        Label lblDetay = new Label
                        {
                            Text = $"{eleman.Ad} {eleman.BirimFiyat} TL",
                            ForeColor = Color.White,
                            Font = new Font("Arial", 10, FontStyle.Bold),
                            BackColor = Color.Chocolate,
                            TextAlign = ContentAlignment.MiddleCenter,
                            Location = new Point(13, 110),
                            AutoSize = true
                        };
                        lblDetay.Parent = pbox;
                    }
                }
            }
        }
        public List<SepetViewModel> _sepet = new List<SepetViewModel>();
        private void pboxUrunler_Click(object sender, EventArgs e)
        {
            //if (lstProducts.SelectedItem == null) return;
            PictureBox oPictureBox = (PictureBox)sender;
            var urunler = _urunRepo.GetAll().ToList();
            foreach (var item in urunler)
            {
                if (oPictureBox.Name == item.Ad)
                {
                    var urun = item as Urun;
                    var sepetUrun = _sepet.FirstOrDefault(x => x.Urun.Id == urun.Id);
                    if (sepetUrun == null)
                    {
                        _sepet.Add(new SepetViewModel
                        {
                            Urun = urun,
                            Adet = 1
                        });
                    }
                    else
                    {
                        sepetUrun.Adet++;
                    }
                }
            }
            SepetiDoldur();
        }

        private void SepetiDoldur()
        {
            var toplamFiyat = _sepet.Sum(x => x.AraToplam);
            lblToplam.Text = $"Toplam:{toplamFiyat:c2}";

            lstCart.Columns.Clear();
            lstCart.Items.Clear();
            lstCart.MultiSelect = false;
            lstCart.FullRowSelect = true;
            lstCart.View = View.Details;

            lstCart.Columns.Add("Adet");
            lstCart.Columns.Add("Ürün");
            lstCart.Columns.Add("Ara Toplam");


            foreach (var item in _sepet)
            {
                ListViewItem viewItem = new ListViewItem(item.Adet.ToString());
                viewItem.Tag = item;
                viewItem.SubItems.Add(item.Urun.Ad);
                viewItem.SubItems.Add($"{item.AraToplam:c2}");
                lstCart.Items.Add(viewItem);
            }
            lstCart.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
        }

        private void lstCart_Click(object sender, EventArgs e)
        {
            var secili = lstCart.SelectedItems[0].Tag as SepetViewModel;
            if (secili.Adet == 1)
            {
                _sepet.Remove(secili);
            }
            else
            {
                secili.Adet--;
            }
            SepetiDoldur();
        }
        private void btnGeri_Click(object sender, EventArgs e)
        {
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Show();
            this.Hide();
        }

        private void btn_SiparisAl_Click(object sender, EventArgs e)
        {
            MessageBox.Show("button tık var");
            foreach (var item in _sepet)
            {
                Siparis yeniSiparis = new Siparis()
                {
                    UrunId = item.UrunId,
                    Adet = item.Adet,
                    BirimFiyat = item.BirimFiyat,
                    MasaAd = _oMasa.Name,
                    AraToplam = item.AraToplam,
                    MasaDurum = true

                };
                _siparisRepo.Add(yeniSiparis);

            }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Bitmap Adisyon = new Bitmap(this.tableLayoutPanelsepet.Width, this.tableLayoutPanelsepet.Height);
            lstCart.DrawToBitmap(Adisyon, new System.Drawing.Rectangle(0, 0, this.tableLayoutPanelsepet.Width, this.tableLayoutPanelsepet.Height));

            Bitmap lbl = new Bitmap(this.lblToplam.Width, this.lblToplam.Height);
            lblToplam.DrawToBitmap(lbl, new System.Drawing.Rectangle(0, 0, this.lblToplam.Width, this.lblToplam.Height));

            e.Graphics.DrawImage(Adisyon, 135, 65);
            e.Graphics.DrawImage(lbl, this.lstCart.Width, this.tableLayoutPanelsepet.Height - 300);
        }

        private void btnAdisyonKapat_Click(object sender, EventArgs e)
        {
            PrintDialog daraGridViewPrintDialog = new PrintDialog();
            daraGridViewPrintDialog.Document = printDocument1;
            daraGridViewPrintDialog.UseEXDialog = true;
            printDocument1.Print();
            this.Close();

           // _btn.BackColor = ColorTranslator.FromHtml("#ee7621");
            this.Hide();
        }

    }
}
