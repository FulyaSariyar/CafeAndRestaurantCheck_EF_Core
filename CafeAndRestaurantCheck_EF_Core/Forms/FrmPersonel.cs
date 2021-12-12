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
        private SiparisRepo _siparisRepo = new SiparisRepo();
        public FrmPersonel()
        {
            InitializeComponent();
        }
        Color seciliKatColor = Color.BlueViolet, defaultKatColor = Color.Chocolate;
        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            var binabilgileri = _binaRepo.GetAll().Where(x => x.IsDeleted == false).ToList();
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

        private Button btnMasa;
        protected void btnKat_Click(object sender, EventArgs e)
        {
            var binabilgileri = _binaRepo.GetAll().Where(x => x.IsDeleted == false).ToList();
            // var bosMasalar = _siparisRepo.GetAll().Where();

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
                        btnMasa = new Button
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
                foreach (Button button in flwpBinaBolumleri.Controls)
                {
                    button.BackColor = defaultKatColor;
                    if (button.Text == oButton.Text)
                        button.BackColor = seciliKatColor;
                }
                MasaRenklendir();
            }
            foreach (Button button in flwpMasa.Controls)
            {
                if (button.BackColor == seciliKatColor)
                {
                    button.ContextMenuStrip = MasaContextToolStript(button);
                }
            }
        }
        private ContextMenuStrip myMenu;
        private ContextMenuStrip MasaContextToolStript(Button _btnMasa)
        {
            myMenu = new ContextMenuStrip();
            myMenu.Name = $"{_btnMasa.Name}";
            myMenu.Tag = _btnMasa;

            ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem.Name = $"{_btnMasa.Name}";
            toolStripMenuItem.Text = "Masa Taşı";
            
            ToolStripMenuItem toolStripSubItem;
            foreach (Button button in flwpMasa.Controls)
            {
                if (button.BackColor == defaultKatColor && button.Name != myMenu.Name)
                {
                    toolStripSubItem = new ToolStripMenuItem();
                    toolStripSubItem.Name = $"{button.Name}";
                    toolStripSubItem.Text = $"{button.Name}";
                    toolStripMenuItem.DropDownItems.Add(toolStripSubItem);
                    toolStripSubItem.Tag = _btnMasa.Name;
                    toolStripSubItem.Click += new EventHandler(MasaTasi_Click);

                }
            }
            myMenu.Items.Add(toolStripMenuItem);
            return myMenu;
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

        private void MasaTasi_Click(object sender, EventArgs e)
        {
            //Button oButton = (Button)sender;
            ToolStripMenuItem hedefMasa = (ToolStripMenuItem)sender;
            string kaynakMasa = hedefMasa.Tag.ToString(); 

            var tasinacakSiparisler = _siparisRepo.GetAll()
                .Where(x => x.MasaAd == kaynakMasa && x.IsDeleted == false).ToList();

            foreach (var item in tasinacakSiparisler)
            {
                item.MasaAd = hedefMasa.Name;
                _siparisRepo.Update(item);
            }
            FrmPersonel frmPersonelRefresh= new FrmPersonel();
            this.Close();
            frmPersonelRefresh.Show();

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
