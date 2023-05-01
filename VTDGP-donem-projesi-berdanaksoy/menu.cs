using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VTDGP_donem_projesi_berdanaksoy
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anaEkran anaEkran = new anaEkran();
            anaEkran.Show();
            this.Hide();
            anaEkran.comboBox1.Enabled = false;
            anaEkran.button5.Enabled = false;
        }
    }
}
