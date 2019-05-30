using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace TEKNİK_SERVİS
{
    public partial class markamodel : Form
    {
        public static string baglanticumlesi = (@" Data Source=.\SQLEXPRESS;Initial Catalog=TeknikServis;Integrated Security=true;");
        SqlConnection baglanti = new SqlConnection(baglanticumlesi);
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        public markamodel()
        {
            InitializeComponent();
        }
        //Marka TablomuzaVeri Girişi Yapıtık
        private void markaverigir()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Marka (MarkaAdi) VALUES (@markaadi)", baglanti);


            cmd.Parameters.AddWithValue("@markaadi", textBox1.Text);

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            cmd.ExecuteNonQuery();
            baglanti.Close();
            markakayitGetir();
           
            MessageBox.Show("Verilen Eklendi");
        }
         //CihazTuru TablomuzaVeri Girişi Yapıtık
        private void cihazturuverigir()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO CihazTuru (CihazTuru) VALUES (@cihazturuadi)", baglanti);


            cmd.Parameters.AddWithValue("@cihazturuadi", textBox2.Text);

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            cmd.ExecuteNonQuery();
            baglanti.Close();
            cihazturukayitGetir();
           
            MessageBox.Show("Veriler Eklendi");
        }
          //DataGridView2'e CihazTuru tablosundan veri çektik..
        private void cihazturukayitGetir()
        {
            baglanti.Open();
            string kayit = "SELECT * from CihazTuru";
            komut = new SqlCommand(kayit, baglanti);
            da = new SqlDataAdapter(komut);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }
        
        //DataGridView1'e Marka tablosundan veri çektik..
        private void markakayitGetir()
        {
            baglanti.Open();
            string kayit = "SELECT * from Marka";
            komut = new SqlCommand(kayit, baglanti);
            da = new SqlDataAdapter(komut);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
        SqlCommand cmd = new SqlCommand("INSERT INTO Marka (MarkaAdi) VALUES (@markaadi)", baglanti);


            cmd.Parameters.AddWithValue("@markaadi", textBox1.Text);

            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            cmd.ExecuteNonQuery();
            baglanti.Close();
            

            MessageBox.Show("Verilen Eklendi");
            
        
        }

        private void markamodel_Load(object sender, EventArgs e)
        {
            markakayitGetir();
            markakayitGetir();
            cihazturukayitGetir();
            markakayitGetir();
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cihazturukayitGetir();
            cihazturuverigir();
        }

        //CihazTuru Tablomuzu Güncelledik
        private void button5_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE CihazTuru SET CihazTuru=@turadi WHERE TurID=@id ", baglanti);
            cmd.Parameters.AddWithValue("@id", dataGridView2.CurrentRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("@turadi", textBox2.Text);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            cmd.ExecuteNonQuery();
            baglanti.Close();
            cihazturukayitGetir();
            MessageBox.Show("Veriler Güncellendi");
        }
        //Marka Tablomuzu Güncelledik
        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE Marka SET MarkaAdi=@markaadi WHERE MarkaID=@id ", baglanti);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
            cmd.Parameters.AddWithValue("@markaadi", textBox1.Text);
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            cmd.ExecuteNonQuery();
            baglanti.Close();
            markakayitGetir();
            MessageBox.Show("Veriler Güncellendi");
        }
        //Marka Tablomuzdan Veri Silme İşlemi
        private void button4_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM Marka WHERE MarkaID=@id", baglanti);
            
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);


            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            cmd.ExecuteNonQuery(); baglanti.Close();
            markakayitGetir();


            MessageBox.Show("Silindi.");
        }
        //CihazTuru Tablomuzdan Veri Silme İşlemi
        private void button6_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM CihazTuru WHERE TurID=@id", baglanti);

            cmd.Parameters.AddWithValue("@id", dataGridView2.CurrentRow.Cells[0].Value);


            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            cmd.ExecuteNonQuery(); baglanti.Close();
            cihazturukayitGetir();

            MessageBox.Show("Silindi.");
        }

       
    }
}
