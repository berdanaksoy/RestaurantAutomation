using restaurantAutomation.Classes;
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
    public partial class menu : Form
    {
        public menu()
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
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM menu order by productType", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            PageSwitching.openMainScreen(false,false,true,true,true,menu.ActiveForm);
        }

        private void menu_Load(object sender, EventArgs e)
        {
            updateData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                con.Open();
                cmd = new SqlCommand("SELECT productID FROM menu", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                    con.Open();
                    cmd = new SqlCommand("update tables set bill=bill+(select price from menu where productID=@productID) where tableID=@tableID", con);
                    cmd.Parameters.AddWithValue("tableID", int.Parse(mainScreen.transferİnformation));
                    cmd.Parameters.AddWithValue("productID", int.Parse(textBox1.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                    con.Open();
                    cmd = new SqlCommand("Insert into orders(tableID, [order], price, orderStatus) values(@tableID, (select orderName from menu where productID = @productID), (select price from menu where productID = @productID),'in order')", con);
                    cmd.Parameters.AddWithValue("tableID", int.Parse(mainScreen.transferİnformation));
                    cmd.Parameters.AddWithValue("productID", int.Parse(textBox1.Text));
                    cmd.ExecuteNonQuery();
                    con.Close();

                    con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand();
                    cmd2.Connection = con;
                    da = new SqlDataAdapter("SELECT * FROM orders where tableID ='" + int.Parse(mainScreen.transferİnformation) + "'", con);
                    DataSet ds = new DataSet();
                    da.Fill(ds);
                    dataGridView2.DataSource = ds.Tables[0];
                    con.Close();

                    orders orders = new orders();
                    orders.updateData();
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("productID cannot be left blank.");
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }

}
