using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace restaurantAutomation.Classes
{
    public class SQLoperations
    {
        public static SqlConnection con;
        public static SqlCommand cmd;
        public static SqlDataReader dr;
        public static SqlDataAdapter da;

        public static void connection(string doIt)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=restaurantAutomation;Integrated Security=SSPI");
            if (doIt == "connect" )
            {
                con.Open();
            }
            else if (doIt == "disconnect")
            {
                con.Close();
            }
        }

        public static void fillTable(string query,DataGridView dataGridViewName)
        {
            da = new SqlDataAdapter(query, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridViewName.DataSource = ds.Tables[0];
        }

        public static void commandExecute(string SqlCommand, string[] parameterName, string[] parameterValue )
        {
            cmd = new SqlCommand(SqlCommand, con);
            for (int i = 0; i < parameterName.Length; i++)
            {
                cmd.Parameters.AddWithValue(parameterName[i], parameterValue[i]);
            }
            cmd.ExecuteNonQuery();
        }

        public static void sqlCommandToSqlDataReader(string SqlCommand, string[] parameterName, string[] parameterValue)
        {
            cmd = new SqlCommand(SqlCommand, con);
            for (int i = 0; i < parameterName.Length; i++)
            {
                cmd.Parameters.AddWithValue(parameterName[i], parameterValue[i]);
            }
            SqlDataReader dr = cmd.ExecuteReader();
        }
    }
}
