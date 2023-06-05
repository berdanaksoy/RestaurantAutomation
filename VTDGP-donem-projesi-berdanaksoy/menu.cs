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

        public void dataGuncelle()
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT * FROM menu order by urunTipi", con);
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

        private void menu_Load(object sender, EventArgs e)
        {
            dataGuncelle();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                con.Open();
                cmd = new SqlCommand("SELECT urunID FROM menu",con);
                dr= cmd.ExecuteReader();
                if (dr.Read())
                {
                    if(dr.Read().ToString()==textBox1.Text)
                    {
                        con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                        con.Open();
                        cmd = new SqlCommand("update masalar set hesap=hesap+(select fiyati from menu where urunID=@urunID) where masaID=@masaID", con);
                        cmd.Parameters.AddWithValue("masaID", int.Parse(anaEkran.transferBilgi));
                        cmd.Parameters.AddWithValue("urunID", int.Parse(textBox1.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                        con.Open();
                        cmd = new SqlCommand("Insert into siparisler(masaID, siparisi, fiyati, siparisDurumu) values(@masaID, (select siparisAdi from menu where urunID = @urunID), (select fiyati from menu where urunID = @urunID),'sirada')", con);
                        cmd.Parameters.AddWithValue("masaID", int.Parse(anaEkran.transferBilgi));
                        cmd.Parameters.AddWithValue("urunID", int.Parse(textBox1.Text));
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                        con.Open();
                        SqlCommand cmd2 = new SqlCommand();
                        cmd2.Connection = con;
                        da = new SqlDataAdapter("SELECT * FROM siparisler where masaID ='" + int.Parse(anaEkran.transferBilgi) + "' order by siparisID", con);
                        DataSet ds = new DataSet();
                        da.Fill(ds);
                        dataGridView2.DataSource = ds.Tables[0];
                        con.Close();

                        siparisler siparisler = new siparisler();
                        siparisler.dataGuncelle();
                    }
                    else
                    {
                        MessageBox.Show("Lütfen menude olan bır urunID giriniz.");
                    }
                }
                con.Close();
            } 
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }

}
