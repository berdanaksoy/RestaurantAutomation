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
    public partial class adminEditScreen : Form
    {
        public adminEditScreen()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        private void adminEditScreen_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM adminLogin order by adminID", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PageSwitching.openAdminScreen();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool check = false;
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            cmd = new SqlCommand("select * from adminLogin where adminName=@adminName and password=@password", con);
            cmd.Parameters.AddWithValue("adminName", textBox7.Text);
            cmd.Parameters.AddWithValue("password",textBox2.Text);
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (textBox7.Text == dr["adminName"].ToString() && textBox2.Text == dr["password"].ToString())
                {
                        check = true;
                }
            }
            if (check==true)
            {
                con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                con.Open();
                cmd = new SqlCommand("UPDATE adminLogin SET password = @password WHERE adminName = @adminName", con);
                cmd.Parameters.AddWithValue("adminName", textBox7.Text);
                cmd.Parameters.AddWithValue("password", textBox3.Text);
                cmd.ExecuteNonQuery();

                da = new SqlDataAdapter("SELECT * FROM adminLogin order by adminID", con);
                DataSet dss = new DataSet();
                da.Fill(dss);
                dataGridView1.DataSource = dss.Tables[0];
                con.Close();

                MessageBox.Show("Your password has changed.");
            }
            else
            {
                MessageBox.Show("Your administrator name or password is incorrect.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text=="" && textBox5.Text=="")
            {
                MessageBox.Show("Administrator name or password cannot be left blank.");
            }
            else
            {
                con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                con.Open();
                cmd = new SqlCommand("insert into adminLogin (adminName,password) values (@adminName,@password) ", con);
                cmd.Parameters.AddWithValue("adminName", textBox4.Text);
                cmd.Parameters.AddWithValue("password", textBox5.Text);
                cmd.ExecuteNonQuery();

                da = new SqlDataAdapter("SELECT * FROM adminLogin order by adminID", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox6.Text)==1)
            {
                MessageBox.Show("The main administrator cannot be deleted.");
            }
            else
            {
                con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
                con.Open();
                cmd = new SqlCommand("delete from adminLogin where adminID = @adminID", con);
                cmd.Parameters.AddWithValue("adminID", textBox6.Text);
                cmd.ExecuteNonQuery();

                da = new SqlDataAdapter("SELECT * FROM adminLogin order by adminID", con);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
