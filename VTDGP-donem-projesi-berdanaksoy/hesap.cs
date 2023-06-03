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
    public partial class hesap : Form
    {
        public hesap()
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
            anaEkran anaEkran = new anaEkran();
            anaEkran.Show();
            this.Hide();

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
                try
                {
                    int.Parse(textBox1.Text);
                    if (textBox1.Text == "")
                    {
                        MessageBox.Show("Lütfen önce bahşiş yüzdenizi giriniz.");
                    }
                    else
                    {
                        MessageBox.Show("Ödemeniz için garson yönlendirilmiştir.");
                        anaEkran anaEkran = new anaEkran();
                        anaEkran.Show();
                        this.Hide();

                        anaEkran.comboBox1.Enabled = true;
                        anaEkran.button5.Enabled = true;

                        anaEkran.button2.Visible = false;
                        anaEkran.button3.Visible = false;
                        anaEkran.button4.Visible = false;

                        string sorgu = "update masalar set musaitlik = 'bos' where masaID = 1";
                        con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
                        cmd = new SqlCommand(sorgu, con);
                        //cmd.Parameters.AddWithValue("@masaID", comboBox1.SelectedItem);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch
                {
                    MessageBox.Show("Lütfen bahşiş kısmına sayı giriniz.");
                    textBox1.Clear();

                }
            }
           else
            {
                MessageBox.Show("Eksi bahşiş giremezsiniz.");
                textBox1.Clear();
            }
        }

        private void hesap_Load(object sender, EventArgs e)
        {
            con = new SqlConnection("server=BERDAN\\SQLEXPRESS; Initial Catalog=VTDGP Proje Restaurant;Integrated Security=SSPI");
            con.Open();
            da = new SqlDataAdapter("SELECT siparisi as 'Siparisiniz' , fiyati as 'Fiyati' FROM siparisler where masaID = 1", con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];

            cmd = new SqlCommand("Select hesap from masalar where masaID=1", con);
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
    }
}
