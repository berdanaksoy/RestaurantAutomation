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
    public partial class employees : Form
    {
        public employees()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        private void employees_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM employees order by employeeID", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PageSwitching.openAdminScreen();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            con.Open();
            cmd = new SqlCommand("DELETE FROM employees WHERE employeeID=@employeeID", con);
            cmd.Parameters.AddWithValue("employeeID",textBox1.Text);
            cmd.ExecuteNonQuery();

            da = new SqlDataAdapter("SELECT * FROM employees order by employeeID", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int counter = 0;
            string text = textBox5.Text;
            foreach (char txt in text)
            {
                counter++;
            }

            int counter2 = 0;
            string text2 = textBox6.Text;
            foreach (char txt in text)
            {
                counter2++;
            }

            if (counter==11 && counter2==11)
            {
                con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                con.Open();
                cmd = new SqlCommand("Insert into employees (name,surname,number,ID_number,address,salary,position) values (@name,@surname,@number,@ID_number,@address,@salary,@position)", con);
                cmd.Parameters.AddWithValue("name", textBox3.Text);
                cmd.Parameters.AddWithValue("surname", textBox4.Text);
                cmd.Parameters.AddWithValue("number", textBox5.Text);
                cmd.Parameters.AddWithValue("ID_number", textBox6.Text);
                cmd.Parameters.AddWithValue("address", textBox7.Text);
                cmd.Parameters.AddWithValue("salary", int.Parse(textBox8.Text));
                cmd.Parameters.AddWithValue("position", textBox9.Text);
                cmd.ExecuteNonQuery();

                da = new SqlDataAdapter("SELECT * FROM employees order by employeeID", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            else
            {
                MessageBox.Show("ID_number and number must be 11 digits.");
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox8_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void textBox9_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
