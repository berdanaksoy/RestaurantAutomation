using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VTDGP_donem_projesi_berdanaksoy;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace VTDGP_donem_projesi_berdanaksoy
{
    public partial class siparis : Form
    {
        public siparis()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        public void dataGuncelle()
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            da = new SqlDataAdapter("SELECT * FROM siparisler where masaID ='" + int.Parse(anaEkran.transferBilgi) + "' order by siparisID", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            anaEkran anaEkran = new anaEkran();
            anaEkran.Show();
            this.Hide();

            anaEkran.comboBox1.Text = anaEkran.transferBilgi.ToString();

            anaEkran.comboBox1.Enabled = false;
            anaEkran.button5.Enabled = false;

            anaEkran.button2.Visible = true;
            anaEkran.button3.Visible = true;
            anaEkran.button4.Visible = true;
        }

        private void siparis_Load(object sender, EventArgs e)
        {
            dataGuncelle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            cmd = new SqlCommand("select siparisDurumu FROM siparisler WHERE siparisID=@siparisID", con);
            cmd.Parameters.AddWithValue("siparisID", int.Parse(textBox1.Text));
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                if (dr["siparisDurumu"].ToString()=="sirada")
                {
                    con.Close();
                    con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("DELETE FROM siparisler WHERE siparisID=@siparisID", con);
                    cmd2.Parameters.AddWithValue("siparisID", int.Parse(textBox1.Text));
                    cmd2.ExecuteNonQuery();
                    con.Close();

                    dataGuncelle();

                    siparisler siparisler = new siparisler();
                    siparisler.dataGuncelle();
                }
                else
                {
                    MessageBox.Show("Siparisiniz hazirlandigi veya servis edildigi icin iptal edemezsiniz.");
                }
            }
        }
    }
}
