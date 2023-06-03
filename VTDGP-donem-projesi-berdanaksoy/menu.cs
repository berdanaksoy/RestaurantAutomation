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

namespace VTDGP_donem_projesi_berdanaksoy
{
    public partial class menu : Form
    {
        public menu()
        {
            InitializeComponent();
           
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        private void button2_Click(object sender, EventArgs e)
        {

            anaEkran anaEkran = new anaEkran();
            anaEkran.Show();
            this.Hide();

            anaEkran.comboBox1.Enabled = false;
            anaEkran.button5.Enabled = false;

            anaEkran.button2.Visible = true;
            anaEkran.button3.Visible = true;
            anaEkran.button4.Visible = true;
        }

        private void menu_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT siparisAdi as 'Secenekler', fiyati as 'Fiyati' FROM menu",con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            cmd = new SqlCommand("insert into siparisler values (1,@siparis)");
            da = new SqlDataAdapter(cmd);
            cmd.Parameters.AddWithValue("@siparis", dataGridView1.SelectedCells[0].ToString());
            cmd = new SqlCommand("insert into masalar (hesap) values (menu.fiyati where urunID = )");
            con.Open();

            da = new SqlDataAdapter("SELECT siparisi as 'Siparis' FROM siparisler where masaID = 1", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView2.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }

}
