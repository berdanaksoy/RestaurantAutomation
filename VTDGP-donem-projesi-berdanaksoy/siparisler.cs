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

namespace VTDGP_donem_projesi_berdanaksoy
{
    public partial class siparisler : Form
    {
        public siparisler()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        private void siparisler_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM siparisler", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();

            comboBox1.Items.Add("Hazirlaniyor");
            comboBox1.Items.Add("Servis Edildi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yoneticiEkrani yoneticiEkrani = new yoneticiEkrani();
            yoneticiEkrani.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            cmd = new SqlCommand("DELETE FROM siparisler WHERE siparisID=@siparisID", con);
            cmd.Parameters.AddWithValue("siparisID",int.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();

            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            da = new SqlDataAdapter("SELECT * FROM siparisler", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            cmd = new SqlCommand("UPDATE siparisler SET siparisDurumu=@siparisDurumu WHERE siparisID=@siparisID", con);
            cmd.Parameters.AddWithValue("siparisID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("siparisDurumu",comboBox1.Text);
            cmd.ExecuteNonQuery();

            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            da = new SqlDataAdapter("SELECT * FROM siparisler", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
