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

namespace restaurantAutomation
{
    public partial class mainScreen : Form
    {
        public mainScreen()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public static string transferBilgi;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            adminLoginScreen adminLoginScreen = new adminLoginScreen();
            adminLoginScreen.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bill hesap = new bill();
            hesap.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            order siparis = new order();
            siparis.Show();
            this.Hide();
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

            button2.Visible = true;
            button3.Visible = true;
            button4.Visible = true;

            string sorgu = "update masalar set musaitlik = 'dolu' where masaID = @masaID";
            transferBilgi = comboBox1.Text;
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@masaID", comboBox1.SelectedItem);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button5.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void anaEkran_Shown(object sender, EventArgs e)
        {
            string sorgu = "SELECT * FROM masalar where musaitlik=@musaitlik";
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            cmd = new SqlCommand(sorgu, con);
            cmd.Parameters.AddWithValue("@musaitlik", "bos");
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["masaID"]);
            }
            con.Close();

            button5.Enabled = false;
        }
    }
  
}
