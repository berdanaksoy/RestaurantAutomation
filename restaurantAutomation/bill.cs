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

namespace restaurantAutomation
{
    public partial class bill : Form
    {
        public bill()
        {
            InitializeComponent();
        }

        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;
        SqlDataAdapter da;

        int hafiza;

        private void button2_Click(object sender, EventArgs e)
        {
            mainScreen anaEkran = new mainScreen();
            anaEkran.Show();
            this.Hide();

            anaEkran.comboBox1.Text = mainScreen.transferBilgi.ToString();

            anaEkran.comboBox1.Enabled = false;
            anaEkran.button5.Enabled = false;

            anaEkran.button2.Visible = true;
            anaEkran.button3.Visible = true;
            anaEkran.button4.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.Parse(textBox2.Text)>=hafiza)
            {
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Lütfen önce bahşiş yüzdenizi giriniz.");
                    }
                    else
                    {
                        MessageBox.Show("Ödemeniz için garson yönlendirilmiştir.");
                        mainScreen anaEkran = new mainScreen();
                        anaEkran.Show();
                        this.Hide();

                        anaEkran.comboBox1.Enabled = true;
                        anaEkran.button5.Enabled = true;

                        anaEkran.button2.Visible = false;
                        anaEkran.button3.Visible = false;
                        anaEkran.button4.Visible = false;

                        con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                        cmd = new SqlCommand("DELETE FROM siparisler WHERE masaID=@masaID", con);
                        cmd.Parameters.AddWithValue("@masaID", int.Parse(mainScreen.transferBilgi));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                        cmd = new SqlCommand("update masalar set musaitlik = 'bos' where masaID = @masaID", con);
                        cmd.Parameters.AddWithValue("@masaID", int.Parse(mainScreen.transferBilgi));
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();

                        orders siparisler = new orders();
                        siparisler.dataGuncelle();
                    }
            }
           else
            {
                MessageBox.Show("Bahşiş miktarı en az %1 olmalı..");
                textBox1.Clear();
            }
        }

        private void hesap_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            cmd = new SqlCommand();
            cmd.Connection = con;
            da = new SqlDataAdapter("SELECT * FROM siparisler where masaID ='" + int.Parse(mainScreen.transferBilgi) + "' order by siparisID", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];


            cmd = new SqlCommand("SELECT hesap FROM masalar where masaID ='" + int.Parse(mainScreen.transferBilgi) + "'", con);
            con.Open();
            dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                textBox2.Text = dr["hesap"].ToString();
            }
            con.Close();

            hafiza = int.Parse(textBox2.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                textBox2.Text = (((int.Parse(textBox1.Text) * hafiza) / 100) + hafiza).ToString();
            }
            catch 
            {
                textBox2.Text = hafiza.ToString();
            }
            
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
