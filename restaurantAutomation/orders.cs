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

namespace restaurantAutomation
{
    public partial class orders : Form
    {
        public orders()
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
            da = new SqlDataAdapter("SELECT * FROM orders where orderStatus!='served'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void orders_Load(object sender, EventArgs e)
        {
            updateData();

            comboBox1.Items.Add("preparing");
            comboBox1.Items.Add("served");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PageSwitching.openAdminScreen();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            con.Open();
            cmd = new SqlCommand("DELETE FROM orders WHERE orderID=@orderID", con);
            cmd.Parameters.AddWithValue("orderID",int.Parse(textBox2.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            updateData();
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            con.Open();
            cmd = new SqlCommand("UPDATE orders SET orderStatus=@orderStatus WHERE orderID=@orderID", con);
            cmd.Parameters.AddWithValue("orderID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("orderStatus",comboBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            updateData();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
