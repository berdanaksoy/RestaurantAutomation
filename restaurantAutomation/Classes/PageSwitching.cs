using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace restaurantAutomation.Classes
{
    public class PageSwitching
    {

        public static void openAdminEditScreen(Form currentScreen)
        {
            adminEditScreen adminEditScreen = new adminEditScreen();
            adminEditScreen.Show();
            currentScreen.Hide();
        }

        public static void openAdminLoginScreen(Form currentScreen)
        {
            adminLoginScreen adminLoginScreen = new adminLoginScreen();
            adminLoginScreen.Show();
            currentScreen.Hide();
        }

        public static void openAdminScreen(bool button3Visible , bool button5Visible, Form currentScreen)
        {
            adminScreen adminScreen = new adminScreen();
            adminScreen.Show();

            adminScreen.button3.Visible = button3Visible;
            adminScreen.button5.Visible = button5Visible;

            currentScreen.Hide();
        }
        public static void openAdminScreen(Form currentScreen)
        {
            adminScreen adminScreen = new adminScreen();
            adminScreen.Show();
            currentScreen.Hide();
        }

        public static void openBill(Form currentScreen)
        {
            bill bill = new bill();
            bill.Show();
            currentScreen.Hide();
        }

        public static void openEmployees(Form currentScreen)
        {
            employees employees = new employees();
            employees.Show();
            currentScreen.Hide();
        }

        public static void openExamineTheTable(Form currentScreen)
        {
            examineTheTables examineTheTables = new examineTheTables();
            examineTheTables.Show();
            currentScreen.Hide();
        }

        public static void openMainScreen(bool comboBox1Enabled, bool button5Enabled,bool button2Visible, bool button3Visible,bool button4Visible, Form currentScreen)
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

            currentScreen.Hide();
        }

        public static void openMenu(Form currentScreen)
        {
            menu menu = new menu();
            menu.Show();
            currentScreen.Hide();
        }

        public static void openMenuEditScreen(Form currentScreen)
        {
            menuEditScreen menuEditScreen = new menuEditScreen();
            menuEditScreen.Show();
            currentScreen.Hide();
        }

        public static void openOrder(Form currentScreen)
        {
            order order = new order();
            order.Show();
            currentScreen.Hide();
        }

        public static void openOrders(Form currentScreen)
        {
            orders orders = new orders();
            orders.Show();
            currentScreen.Hide();
        }
    }
}
