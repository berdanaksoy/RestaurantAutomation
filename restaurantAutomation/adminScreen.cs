using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurantAutomation
{
    public partial class adminScreen : Form
    {
        public adminScreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            adminLoginScreen adminLoginScreen = new adminLoginScreen();
            adminLoginScreen.Show();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employees employees = new employees();
            employees.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            orders orders = new orders();
            orders.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            adminEditScreen adminEditScreen = new adminEditScreen();
            adminEditScreen.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            menuEditScreen menuEditScreen = new menuEditScreen();
            menuEditScreen.Show();
            this.Hide();
        }
    }
}
