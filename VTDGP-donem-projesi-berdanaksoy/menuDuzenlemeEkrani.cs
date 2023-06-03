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
    public partial class menuDuzenlemeEkrani : Form
    {
        public menuDuzenlemeEkrani()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        private void button2_Click(object sender, EventArgs e)
        {
            yoneticiEkrani yoneticiEkrani = new yoneticiEkrani();
            yoneticiEkrani.Show();
            this.Hide();
        }

        private void menuDuzenlemeEkrani_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM menu", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            cmd = new SqlCommand("delete from menu where urunID = @urunID",con);
            cmd.Parameters.AddWithValue("urunID",int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();

            da = new SqlDataAdapter("SELECT * FROM menu", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                if (textBox1.Text != "" && textBox3.Text!="")
                {
                    int.Parse(textBox2.Text);
                    if (int.Parse(textBox2.Text) >= 0)
                    {
                        con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                        con.Open();
                        cmd = new SqlCommand("insert into menu (siparisAdi,fiyati,urunTipi) values (@siparisAdi,@fiyati,@urunTipi) ", con);
                        cmd.Parameters.AddWithValue("siparisAdi", textBox1.Text);
                        cmd.Parameters.AddWithValue("fiyati", int.Parse(textBox2.Text));
                        cmd.Parameters.AddWithValue("urunTipi", textBox3.Text);
                        cmd.ExecuteNonQuery();

                        da = new SqlDataAdapter("SELECT * FROM menu", con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView1.DataSource = ds.Tables[0];
                        con.Close();
                    }
                    else
                    {
                        MessageBox.Show("Fiyatı eksi giremezsiniz.");
                    }
                }
                else
                {
                    MessageBox.Show("Siparis adini ve urun tipini bos bırakamazsınız.");
                }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);    //sayı engelleme
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); //harf engelleme
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);    //sayı engelleme
        }

        private void button4_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM menu where siparisAdi=@siparisAdi", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
