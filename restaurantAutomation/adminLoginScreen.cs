using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace restaurantAutomation
{
    public partial class adminLoginScreen : Form
    {
        public adminLoginScreen()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        private void button2_Click(object sender, EventArgs e)
        {
            mainScreen anaEkran = new mainScreen();
            anaEkran.Show();
            this.Hide();

            anaEkran.comboBox1.Enabled = false;
            anaEkran.button5.Enabled = false;

            anaEkran.button2.Visible = true;
            anaEkran.button3.Visible = true;
            anaEkran.button4.Visible = true;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM yoneticiGirisi where yoneticiAdi=@user AND sifre=@pass";
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@user", textBox1.Text);
            cmd.Parameters.AddWithValue("@pass", textBox2.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string admin = textBox1.Text;
                if (textBox1.Text=="admin")
                {
                    adminScreen yoneticiEkrani = new adminScreen();
                    yoneticiEkrani.Show();
                    this.Hide();
                }
                else  
                {
                    adminScreen yoneticiEkrani = new adminScreen();
                    yoneticiEkrani.Show();
                    this.Hide();
                    yoneticiEkrani.button3.Visible=false;
                    yoneticiEkrani.button5.Visible = false;
                }
                
            }
            else
            {
                MessageBox.Show("Kullanıcı adını ve şifrenizi kontrol ediniz.");
            }
            con.Close();
        }
    }
}
