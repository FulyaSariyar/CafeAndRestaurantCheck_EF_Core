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
    public partial class FrmPersonel : Form
    {
        private BinaRepo _binaRepo = new BinaRepo();
        private CafeContext _cafeContext = new CafeContext();
        private SiparisRepo _siparisRepo= new SiparisRepo();
        public FrmPersonel()
        {
            InitializeComponent();
        }
        Color seciliKatColor = Color.BlueViolet, defaultKatColor = Color.Chocolate;
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var binabilgileri = _binaRepo.GetAll().ToList();
            for (int i = 0; i < binabilgileri.Count; i++)
            {
                var siparisler = new List<Siparis>();
                var btnKat = new Button
                {

                    Size = new Size(200, 90),
                    BackColor = ColorTranslator.FromHtml("#ee7621"),
                    Text = binabilgileri[i].BinaBolumAdi,
                    ForeColor = Color.White
                };

                for (int j = 1; j <= Convert.ToInt32(binabilgileri[i].MasaAdet); j++)
                {
                    siparisler.Add(new Siparis()
                    {
                        MasaAd = $"MASA {j}",
                    });
                }

                btnKat.Name = $"{binabilgileri[i].BinaBolumAdi}";
                btnKat.Click += new EventHandler(btnKat_Click);
                flwpBinaBolumleri.Controls.Add(btnKat);
            }
        }
        protected void btnKat_Click(object sender, EventArgs e)
        {
            var binabilgileri = _binaRepo.GetAll().ToList();

            //flpMenuElemanlari.Controls.Clear();
            Button oButton = (Button)sender;//secili buton
            foreach (var item in binabilgileri)
            {

                if (oButton.Name == item.BinaBolumAdi)
                {
                    flwpMasa.Controls.Clear();
                    var siparisler = new List<Siparis>();
                    for (int i = 1; i <= int.Parse(item.MasaAdet); i++)
                    {
                        var btnMasa = new Button

                        {
                            Size = new Size(150, 150),
                            //BackColor = ColorTranslator.FromHtml("#7F7F7F"),//#a45117//CD661D
                            BackColor = Color.Chocolate,
                            Text = $"MASA {i}",
                            ForeColor = Color.White
                        };
                        btnMasa.Name = $"{oButton.Text}MASA{i}";
                        btnMasa.Click += new EventHandler(btnMasa_Click);
                        flwpMasa.Controls.Add(btnMasa);
                    }
                }  
            }
            foreach (Button button in flwpBinaBolumleri.Controls)
            {
                button.BackColor = defaultKatColor;
                if (button.Text == oButton.Text)
                    button.BackColor = seciliKatColor;
            }
            MasaRenklendir();
        }
        private void MasaRenklendir()
        {
            var mevcutSiparisler = _siparisRepo.GetAll(x => x.IsDeleted == false);
            foreach (Button button in flwpMasa.Controls)
            {
                button.BackColor = defaultKatColor;
                if (mevcutSiparisler.Any(x => x.MasaAd.Equals(button.Name)))
                {
                    button.BackColor = seciliKatColor;
                }
            }
        }

        protected void btnMasa_Click(object sender, EventArgs e)
        {
            Button oMasa = (Button)sender;
            FrmSiparis _frmSiparis = new FrmSiparis(oMasa);
            _frmSiparis.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            _frmSiparis.Show();
            this.Hide();

           
        }
    }
}
