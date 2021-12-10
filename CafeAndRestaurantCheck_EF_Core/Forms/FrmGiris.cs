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
    public partial class FrmGiris : Form
    {
        public FrmGiris()
        {
            InitializeComponent();
        }


        private void btnYonetici_Click(object sender, EventArgs e)
        {
            FrmKurulum frmKurulum = new FrmKurulum();
            frmKurulum.Show();
            this.Hide();
        }


        private void btnKapat_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }

        private void btnPersonel_Click(object sender, EventArgs e)
        {
            FrmPersonel frmPersonel = new FrmPersonel();
            frmPersonel.Show();
            this.Hide();
        }
    }
}
