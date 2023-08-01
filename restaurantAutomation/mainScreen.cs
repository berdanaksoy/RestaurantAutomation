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

        public static string transferİnformation;

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            adminLoginScreen adminLoginScreen = new adminLoginScreen();
            adminLoginScreen.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bill bill = new bill();
            bill.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            order order = new order();
            order.Show();
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

            string query = "update tables set availability = 'full' where tableID = @tableID";
            transferİnformation = comboBox1.Text;
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@tableID", comboBox1.SelectedItem);
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
            string query = "SELECT * FROM tables where availability=@availability";
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@availability", "empty");
            con.Open();
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr["tableID"]);
            }
            con.Close();

            button5.Enabled = false;
        }
    }
  
}
