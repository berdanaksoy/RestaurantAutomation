using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurantAutomation.Classes
{
    public class PageSwitching
    {

        public static void openAdminEditScreen()
        {
            adminEditScreen adminEditScreen = new adminEditScreen();
            adminEditScreen.Show();
        }

        public static void openAdminLoginScreen()
        {
            adminLoginScreen adminLoginScreen = new adminLoginScreen();
            adminLoginScreen.Show();
        }

        public static void openAdminScreen(bool button3Visible , bool button5Visible)
        {
            adminScreen adminScreen = new adminScreen();
            adminScreen.Show();

            adminScreen.button3.Visible = button3Visible;
            adminScreen.button5.Visible = button5Visible;
        }
        public static void openAdminScreen()
        {
            adminScreen adminScreen = new adminScreen();
            adminScreen.Show();
        }

        public static void openBill()
        {
            bill bill = new bill();
            bill.Show();
        }

        public static void openEmployees()
        {
            employees employees = new employees();
            employees.Show();
        }

        public static void openExamineTheTable()
        {
            examineTheTables examineTheTables = new examineTheTables();
            examineTheTables.Show();
        }

        public static void openMainScreen(bool comboBox1Enabled, bool button5Enabled,bool button2Visible, bool button3Visible,bool button4Visible)
        {
            mainScreen mainScreen = new mainScreen();
            mainScreen.Show();

            mainScreen.comboBox1.Enabled = comboBox1Enabled;
            mainScreen.button5.Enabled = button5Enabled;
            mainScreen.button2.Visible = button2Visible;
            mainScreen.button3.Visible = button3Visible;
            mainScreen.button4.Visible = button4Visible;

            try
            {
                mainScreen.comboBox1.Text = mainScreen.transferİnformation;
            }
            catch{}
            
        }

        public static void openMenu()
        {
            menu menu = new menu();
            menu.Show();
        }

        public static void openMenuEditScreen()
        {
            menuEditScreen menuEditScreen = new menuEditScreen();
            menuEditScreen.Show();
        }

        public static void openOrder()
        {
            order order = new order();
            order.Show();
        }

        public static void openOrders()
        {
            orders orders = new orders();
            orders.Show();
        }
    }
}
