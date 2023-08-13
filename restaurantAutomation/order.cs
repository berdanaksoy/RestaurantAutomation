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
using restaurantAutomation.Classes;
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
            PageSwitching.openMainScreen(false,false,true,true,true);
            this.Hide();
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
                if (dr["orderStatus"].ToString()=="in order")
                {
                    con.Close();
                    con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM orders WHERE orderID=@orderID", con);
                    cmd2.Parameters.AddWithValue("orderID", int.Parse(textBox1.Text));
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    int priceMemory;
                    con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                    con.Open();
                    SqlCommand cmd4 = new SqlCommand("select price from orders where orderID=@orderID", con);
                    cmd4.Parameters.AddWithValue("orderID", int.Parse(textBox1.Text));
                    priceMemory = cmd4.ExecuteNonQuery();
                    con.Close();

                    con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                    con.Open();
                    SqlCommand cmd3 = new SqlCommand("update tables set bill=bill- "+priceMemory+" where tableID=@tableID",con);
                    cmd3.Parameters.AddWithValue("tableID", int.Parse(mainScreen.transferİnformation));
                    cmd3.ExecuteNonQuery();
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
