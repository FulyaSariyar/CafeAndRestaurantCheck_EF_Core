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
    public partial class FrmRapor : Form
    {
        public FrmRapor()
        {
            InitializeComponent();
        }

        private void btnRaporGeri_Click_1(object sender, EventArgs e)
        {
            FrmGiris frmGiris = new FrmGiris();
            frmGiris.Show();
            this.Hide();
        }

        private void FrmRapor_Load(object sender, EventArgs e)
        {

        }
    }
}
