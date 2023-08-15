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
    public partial class menuEditScreen : Form
    {
        public menuEditScreen()
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
            PageSwitching.openAdminScreen(menuEditScreen.ActiveForm);
            this.Hide();
        }

        private void menuEditScreen_Load(object sender, EventArgs e)
        {
            updateData();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            con.Open();
            cmd = new SqlCommand("delete from menu where productID = @productID",con);
            cmd.Parameters.AddWithValue("productID",int.Parse(textBox4.Text));
            cmd.ExecuteNonQuery();
            con.Close();

            updateData();

            menu menu = new menu();
            menu.updateData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                if (textBox1.Text != "" && textBox3.Text!="")
                {
                    int.Parse(textBox2.Text);
                    if (int.Parse(textBox2.Text) >= 0)
                    {
                        con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                        con.Open();
                        cmd = new SqlCommand("insert into menu (orderName,price,productType) values (@orderName,@price,@productType) ", con);
                        cmd.Parameters.AddWithValue("orderName", textBox1.Text);
                        cmd.Parameters.AddWithValue("price", int.Parse(textBox2.Text));
                        cmd.Parameters.AddWithValue("productType", textBox3.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();

                        updateData();
                    }
                    else
                    {
                        MessageBox.Show("You can't enter the price minus.");
                    }
                }
                else
                {
                    MessageBox.Show("You can't leave the order name and product type blank.");
                }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }
    }
}
