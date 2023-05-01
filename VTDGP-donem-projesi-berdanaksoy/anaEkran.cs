using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VTDGP_donem_projesi_berdanaksoy
{
    public partial class anaEkran : Form
    {
        public anaEkran()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            yoneticiGirisEkranı yoneticiEkranı = new yoneticiGirisEkranı();
            yoneticiEkranı.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            menu menu = new menu();
            menu.Show();
            this.Hide();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            button5.Enabled = false;
            comboBox1.Enabled = false;

            string sorgu = "update masalar set musaitlik = 'dolu' where masaID = @masaID";
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@masaID", comboBox1.SelectedIndex+1);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }

        private void anaEkran_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Lutfen once masanızı seciniz!");

            string sorgu = "SELECT * FROM masalar where musaitlik=@musaitlik";
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@musaitlik", "bos");
            con.Open();
            dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                comboBox1.Items.Add("MASA "+dr["masaID"]);
            }
            con.Close();
        }
    }
}
