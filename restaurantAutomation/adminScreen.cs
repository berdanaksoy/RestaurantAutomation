using restaurantAutomation.Classes;
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

        private void button2_Click(object sender, EventArgs e)
        {
            PageSwitching.openAdminLoginScreen();
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PageSwitching.openEmployees();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PageSwitching.openOrders();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            PageSwitching.openExamineTheTable();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            PageSwitching.openMenuEditScreen();
            this.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            PageSwitching.openAdminEditScreen();
            this.Hide();
        }
    }
}
