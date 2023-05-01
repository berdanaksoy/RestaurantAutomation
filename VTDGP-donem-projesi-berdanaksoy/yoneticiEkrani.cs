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
    public partial class yoneticiEkrani : Form
    {
        public yoneticiEkrani()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yoneticiGirisEkranı yoneticiGirisEkranı = new yoneticiGirisEkranı();
            yoneticiGirisEkranı.Show();
            this.Hide();
        }
    }
}
