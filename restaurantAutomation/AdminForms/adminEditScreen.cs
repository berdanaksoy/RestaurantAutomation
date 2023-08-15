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

        private void adminEditScreen_Load(object sender, EventArgs e)
        {
            SQLoperations.connection("connect");
            SQLoperations.fillTable("SELECT * FROM adminLogin order by adminID", dataGridView1);
            SQLoperations.connection("disconnect");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            PageSwitching.openAdminScreen(adminEditScreen.ActiveForm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool check = false;
            SQLoperations.connection("connect");
            string[] parameterNames = {"adminName","password" };
            string[] parameterValues = {textBox7.Text,textBox2.Text };
            SQLoperations.sqlCommandToSqlDataReader("select * from adminLogin where adminName=@adminName and password=@password",parameterNames,parameterValues);
            if (SQLoperations.dr.Read())
            {
                if (textBox7.Text == SQLoperations.dr["adminName"].ToString() && textBox2.Text == SQLoperations.dr["password"].ToString())
                {
                    check = true;
                }
            }
            if (check == true)
            {
                SQLoperations.connection("connect");
                string[] parameterNames2 = { "adminName", "password" };
                string[] parameterValues2 = { textBox7.Text, textBox3.Text };
                SQLoperations.commandExecute("UPDATE adminLogin SET password = @password WHERE adminName = @adminName", parameterNames2, parameterValues2);

                SQLoperations.fillTable("SELECT * FROM adminLogin order by adminID", dataGridView1);
                SQLoperations.connection("disconnect");

                MessageBox.Show("Your password has changed.");
            }
            else
            {
                MessageBox.Show("Your administrator name or password is incorrect.");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" && textBox5.Text == "")
            {
                MessageBox.Show("Administrator name or password cannot be left blank.");
            }
            else
            {
                SQLoperations.connection("connect");
                string[] parameterNames = { "adminName", "password" };
                string[] parameterValues = { textBox4.Text, textBox5.Text };
                SQLoperations.commandExecute("insert into adminLogin (adminName,password) values (@adminName,@password", parameterNames, parameterValues);

                SQLoperations.fillTable("SELECT * FROM adminLogin order by adminID", dataGridView1);
                SQLoperations.connection("disconnect");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox6.Text) == 1)
            {
                MessageBox.Show("The main administrator cannot be deleted.");
            }
            else
            {
                SQLoperations.connection("connect");
                string[] parameterNames = { "adminID" };
                string[] parameterValues = { textBox6.Text };
                SQLoperations.commandExecute("delete from adminLogin where adminID = @adminID", parameterNames, parameterValues);

                SQLoperations.fillTable("SELECT * FROM adminLogin order by adminID", dataGridView1);
                SQLoperations.connection("disconnect");
            }
        }

        private void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
