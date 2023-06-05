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
    public partial class yoneticiDuzenlemeEkrani : Form
    {
        public yoneticiDuzenlemeEkrani()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        private void yoneticiDuzenlemeEkrani_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM yoneticiGirisi order by yoneticiID", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            yoneticiEkrani yoneticiEkrani = new yoneticiEkrani();
            yoneticiEkrani.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool check = false;
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            cmd = new SqlCommand("select * from yoneticiGirisi where yoneticiAdi=@yoneticiAdi and sifre=@sifre", con);
            cmd.Parameters.AddWithValue("yoneticiAdi", textBox7.Text);
            cmd.Parameters.AddWithValue("sifre",textBox2.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (textBox7.Text == dr["yoneticiAdi"].ToString() && textBox2.Text == dr["sifre"].ToString())
                {
                        check = true;
                }
            }
            if (check==true)
            {
                con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                con.Open();
                cmd = new SqlCommand("UPDATE yoneticiGirisi SET sifre = @sifre WHERE yoneticiAdi = @yoneticiAdi", con);
                cmd.Parameters.AddWithValue("yoneticiAdi", textBox7.Text);
                cmd.Parameters.AddWithValue("sifre", textBox3.Text);
                cmd.ExecuteNonQuery();

                da = new SqlDataAdapter("SELECT * FROM yoneticiGirisi order by yoneticiID", con);
                DataSet dss = new DataSet();
                da.Fill(dss);
                dataGridView1.DataSource = dss.Tables[0];
                con.Close();

                MessageBox.Show("Sifreniz degismistir.");
            }
            else
            {
                MessageBox.Show("Yonetici adi veya sifreniz yanlis.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text=="" && textBox5.Text=="")
            {
                MessageBox.Show("Yonetici adi ve sifre bos birakilamaz.");
            }
            else
            {
                con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                con.Open();
                cmd = new SqlCommand("insert into yoneticiGirisi (yoneticiAdi,sifre) values (@yoneticiAdi,@sifre) ", con);
                cmd.Parameters.AddWithValue("yoneticiAdi", textBox4.Text);
                cmd.Parameters.AddWithValue("sifre", textBox5.Text);
                cmd.ExecuteNonQuery();

                da = new SqlDataAdapter("SELECT * FROM yoneticiGirisi order by yoneticiID", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox6.Text)==1)
            {
                MessageBox.Show("Ana yonetici silinemez.");
            }
            else
            {
                con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                con.Open();
                cmd = new SqlCommand("delete from yoneticiGirisi where yoneticiID = @yoneticiID", con);
                cmd.Parameters.AddWithValue("yoneticiID", textBox6.Text);
                cmd.ExecuteNonQuery();

                da = new SqlDataAdapter("SELECT * FROM yoneticiGirisi order by yoneticiID", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
