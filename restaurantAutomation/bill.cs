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
    public partial class bill : Form
    {
        public bill()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        int memory;

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

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox2.Text)>=memory)
            {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Please enter your tip percentage first.");
                    }
                    else
                    {
                        MessageBox.Show("A waiter has been sent for your payment.");
                        mainScreen mainScreen = new mainScreen();
                        mainScreen.Show();
                        this.Hide();

                        mainScreen.comboBox1.Enabled = true;
                        mainScreen.button5.Enabled = true;

                        mainScreen.button2.Visible = false;
                        mainScreen.button3.Visible = false;
                        mainScreen.button4.Visible = false;

                        con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                        cmd = new SqlCommand("DELETE FROM orders WHERE tableID=@tableID", con);
                        cmd.Parameters.AddWithValue("@tableID", int.Parse(mainScreen.transferİnformation));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                        cmd = new SqlCommand("update tables set availability = 'empty' where tableID = @tableID", con);
                        cmd.Parameters.AddWithValue("@tableID", int.Parse(mainScreen.transferİnformation));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        orders orders = new orders();
                        orders.updateData();
                    }
            }
           else
            {
                MessageBox.Show("Tip amount must be at least 1%..");
                textBox1.Clear();
            }
        }

        private void bill_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            cmd = new SqlCommand();
            cmd.Connection = con;
            da = new SqlDataAdapter("SELECT * FROM orders where tableID ='" + int.Parse(mainScreen.transferİnformation) + "' order by orderID", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


            cmd = new SqlCommand("SELECT bill FROM tables where tableID ='" + int.Parse(mainScreen.transferİnformation) + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["bill"].ToString();
            }
            con.Close();

            memory = int.Parse(textBox2.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = (((int.Parse(textBox1.Text) * memory) / 100) + memory).ToString();
            }
            catch 
            {
                textBox2.Text = memory.ToString();
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
