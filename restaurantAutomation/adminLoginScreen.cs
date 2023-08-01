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
            mainScreen mainScreen = new mainScreen();
            mainScreen.Show();
            this.Hide();

            mainScreen.comboBox1.Enabled = false;
            mainScreen.button5.Enabled = false;

            mainScreen.button2.Visible = true;
            mainScreen.button3.Visible = true;
            mainScreen.button4.Visible = true;
        }


        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT * FROM adminLogin where adminName=@adminName AND password=@password";
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("adminName", textBox1.Text);
            cmd.Parameters.AddWithValue("password", textBox2.Text);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                string admin = textBox1.Text;
                if (textBox1.Text=="admin2")
                {
                    adminScreen adminScreen = new adminScreen();
                    adminScreen.Show();
                    this.Hide();
                }
                else  
                {
                    adminScreen adminScreen = new adminScreen();
                    adminScreen.Show();
                    this.Hide();
                    adminScreen.button3.Visible=false;
                    adminScreen.button5.Visible = false;
                }
                
            }
            else
            {
                MessageBox.Show("Check your username and password.");
            }
            con.Close();
        }
    }
}
