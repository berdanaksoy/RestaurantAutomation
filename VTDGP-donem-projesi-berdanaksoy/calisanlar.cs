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
    public partial class calisanlar : Form
    {
        public calisanlar()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        private void calisanlar_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM calisanlar order by calisanID", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yoneticiEkrani yoneticiEkrani = new yoneticiEkrani();
            yoneticiEkrani.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            cmd = new SqlCommand("DELETE FROM calisanlar WHERE calisanID=@calisanID", con);
            cmd.Parameters.AddWithValue("calisanID",textBox1.Text);
            cmd.ExecuteNonQuery();

            da = new SqlDataAdapter("SELECT * FROM calisanlar order by calisanID", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int sayac = 0;
            string text = textBox5.Text;
            foreach (char txt in text)
            {
                sayac++;
            }

            int sayac2 = 0;
            string text2 = textBox6.Text;
            foreach (char txt in text)
            {
                sayac2++;
            }

            if (sayac==11 && sayac2==11)
            {
                con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                con.Open();
                cmd = new SqlCommand("Insert into calisanlar (adi,soyadi,numara,tcNo,adres,maasi,mevkisi) values (@adi,@soyadi,@numara,@tcNo,@adres,@maasi,@mevkisi)", con);
                cmd.Parameters.AddWithValue("adi", textBox3.Text);
                cmd.Parameters.AddWithValue("soyadi", textBox4.Text);
                cmd.Parameters.AddWithValue("numara", textBox5.Text);
                cmd.Parameters.AddWithValue("tcNo", textBox6.Text);
                cmd.Parameters.AddWithValue("adres", textBox7.Text);
                cmd.Parameters.AddWithValue("maasi", int.Parse(textBox8.Text));
                cmd.Parameters.AddWithValue("mevkisi", textBox9.Text);
                cmd.ExecuteNonQuery();

                da = new SqlDataAdapter("SELECT * FROM calisanlar order by calisanID", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            else
            {
                MessageBox.Show("TcNo ve numara 11 haneli olmalı.");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
