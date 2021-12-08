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
    public partial class FrmKurulum : Form
    {
        public FrmKurulum()
        {
            InitializeComponent();
        }

        private void btnBinaKurulum_Click(object sender, EventArgs e)
        {
            FrmBinaBilgileri frmBinaBilgileri =new FrmBinaBilgileri();
            frmBinaBilgileri.Show();

        }
    }
}
