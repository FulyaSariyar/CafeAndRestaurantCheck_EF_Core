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
                    //BackColor = ColorTranslator.FromHtml("#B0B0B0"),ffd2691e
                    BackColor = ColorTranslator.FromHtml("#ee7621"),
                    Text = binabilgileri[i].BinaBolumAdi,
                    ForeColor = Color.White
                };

                for (int j = 1; j <= Convert.ToInt32(binabilgileri[i].MasaAdet); j++)
                {
                    siparisler.Add(new Siparis()
                    {
                        //Durum = SiparisDurum.Aktif,
                        //KatIsim = BinaBilgileri[i].BinaBolumAdi,
                        MasaAd = $"MASA {j}",
                        //MasaSiparisBilgisi = new List<SiparisDetay>()
                    });
                }

                btnKat.Name = $"{binabilgileri[i].BinaBolumAdi}";
                btnKat.Click += new EventHandler(btnKat_Click);
                //btnKat.Parent = groupBox;

                //SiparisBilgileri1[BinaBilgileri[i]]
                //Context.SiparisBilgileri1[BinaBilgileri[i].BinaBolumAdi] = siparisler;
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

                        //masaAd = $"Masa{i}";
                        //binaAd = item.BinaBolumAdi;
                        btnMasa.Click += new EventHandler(btnMasa_Click);
                        flwpMasa.Controls.Add(btnMasa);
                        //Controls.Add(btnMasa); 
                    }

                }
            }
            foreach (Button button in flwpBinaBolumleri.Controls)
            {
                button.BackColor = defaultKatColor;
                if (button.Text == oButton.Text)
                    button.BackColor = seciliKatColor;
            }
        }
        protected void btnMasa_Click(object sender, EventArgs e)
        {
            Button oMasa = (Button)sender;
            FrmSiparis _frmSiparis = new FrmSiparis(oMasa);
            _frmSiparis.Show();
            this.Hide();
        }
    }
}
