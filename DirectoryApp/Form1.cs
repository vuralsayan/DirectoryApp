using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DirectoryApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection(@"Data Source=Vural\SQLEXPRESS;Initial Catalog=DbRehber;Integrated Security=True");


        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From KISILER", baglanti);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        void Temizle()
        {
            TxtID.Text = "";
            TXtAd.Text = "";
            TxtSoyad.Text = "";
            MskTel.Text = "";
            TXtAd.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void BtnEkle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into KISILER (AD, SOYAD, TELEFON, MAIL) VALUES (@P1,@P2,@P3,@P4)", baglanti);
            komut.Parameters.AddWithValue("@P1", TXtAd.Text);
            komut.Parameters.AddWithValue("@P2", TxtSoyad.Text);
            komut.Parameters.AddWithValue("@P3", MskTel.Text);
            komut.Parameters.AddWithValue("@P4", TxtMail.Text);
            komut.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kişi Rehbere Eklendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
            Temizle();
        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            Temizle();
        }
    }
}
