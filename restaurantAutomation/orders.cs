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

namespace restaurantAutomation
{
    public partial class orders : Form
    {
        public orders()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        public void dataGuncelle()
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM siparisler where siparisDurumu!='Servis Edildi'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void siparisler_Load(object sender, EventArgs e)
        {
            dataGuncelle();

            comboBox1.Items.Add("Hazirlaniyor");
            comboBox1.Items.Add("Servis Edildi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminScreen yoneticiEkrani = new adminScreen();
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
            con.Close();

            dataGuncelle();
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
            con.Close();

            dataGuncelle();
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
