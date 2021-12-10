using CafeAndRestaurantCheck_EF_Core.Data;
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
    public partial class FrmSiparis : Form
    {
       private KategoriRepo _kategoriRepo= new KategoriRepo();
        public FrmSiparis()
        {
            InitializeComponent();
        }

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
                    Size = new Size(220, 170),
                    //ClientSize = new Size(200, 180),

                    //ImageLocation = kategoriler[i].Fotograf;
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
        }
        private void pbox_Click(object sender, EventArgs e)
        {

            //flpMenuElemanlari.Controls.Clear();
            //PictureBox oPictureBox = (PictureBox)sender;
            //foreach (var item in menuResimIsimleri)
            //{
            //    if (oPictureBox.Name == item)
            //    {
            //        JsonConverter(item);
            //    }
            //}
        }

        private void btnGeri_Click(object sender, EventArgs e)
        {
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Show();
            this.Hide();
        }
    }
}
