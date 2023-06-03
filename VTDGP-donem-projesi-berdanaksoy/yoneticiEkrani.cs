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

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            calisanlar calisanlar = new calisanlar();
            calisanlar.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            siparisler siparisler = new siparisler();
            siparisler.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            yoneticiDuzenlemeEkrani yoneticiDuzenlemeEkrani = new yoneticiDuzenlemeEkrani();
            yoneticiDuzenlemeEkrani.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menuDuzenlemeEkrani menuDuzenlemeEkrani = new menuDuzenlemeEkrani();
            menuDuzenlemeEkrani.Show();
            this.Hide();
        }
    }
}
