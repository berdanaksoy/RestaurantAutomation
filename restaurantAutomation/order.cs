using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using restaurantAutomation;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace restaurantAutomation
{
    public partial class order : Form
    {
        public order()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        public void updateData()
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            da = new SqlDataAdapter("SELECT * FROM orders where tableID ='" + int.Parse(mainScreen.transferİnformation) + "' order by orderID", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainScreen mainScreen = new mainScreen();
            mainScreen.Show();
            this.Hide();

            mainScreen.comboBox1.Text = mainScreen.transferİnformation.ToString();

            mainScreen.comboBox1.Enabled = false;
            mainScreen.button5.Enabled = false;

            mainScreen.button2.Visible = true;
            mainScreen.button3.Visible = true;
            mainScreen.button4.Visible = true;
        }

        private void order_Load(object sender, EventArgs e)
        {
            updateData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            con.Open();
            cmd = new SqlCommand("select orderStatus FROM orders WHERE orderID=@orderID", con);
            cmd.Parameters.AddWithValue("orderID", int.Parse(textBox1.Text));
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["orderStatus"].ToString()=="order in line")
                {
                    con.Close();
                    con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM orders WHERE orderID=@orderID", con);
                    cmd2.Parameters.AddWithValue("orderID", int.Parse(textBox1.Text));
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    updateData();

                    orders orders = new orders();
                    orders.updateData();
                }
                else
                {
                    MessageBox.Show("You can't cancel your order because it has been prepared or served.");
                }
            }
        }
    }
}
