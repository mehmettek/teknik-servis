using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic; 
namespace TEKNİK_SERVİS
{
    public partial class MüsteriKayit : Form
    {
        
        private string nesne;
        public static string baglanticumlesi = (@" Data Source=.\SQLEXPRESS;Initial Catalog=TeknikServis;Integrated Security=true;");
        SqlConnection baglanti = new SqlConnection(baglanticumlesi);
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        private void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";

        }
        private void kayitGetir()
        {
            baglanti.Open();
            string kayit = "SELECT * from Musteri";
            komut = new SqlCommand(kayit, baglanti);
            da = new SqlDataAdapter(komut);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        private void verigir()
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Musteri (Adı,Soyadı,Telefon,Adres) VALUES (@ad,@soyad,@telefon,@adres)", baglanti);


            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@telefon", textBox3.Text);
            cmd.Parameters.AddWithValue("@adres", textBox4.Text);
            
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
              cmd.ExecuteNonQuery();
            baglanti.Close();
            kayitGetir();
           // clear();
            MessageBox.Show("Eklendi.");
        }

        public MüsteriKayit()
        {
            InitializeComponent();
        }

        private void MüsteriKayit_Load(object sender, EventArgs e)
        {
            kayitGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Boolean durum = true;
            if (textBox1.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!!!");

                durum = false;
            }
            if (textBox2.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!!!");
                durum = false;
            }

            if (textBox3.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!!!");

                durum = false;
            }

            if (textBox4.Text == "")
            {
                MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!!!");

                durum = false;
            }
           


            if (durum)
            {
                verigir();
                kayitGetir();
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SqlCommand cmd = new SqlCommand("DELETE FROM Musteri WHERE MusteriID=@id", baglanti);

            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);


           if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

  cmd.ExecuteNonQuery(); baglanti.Close();
    kayitGetir();


            MessageBox.Show("Silindi.");
        }

        private void button3_Click(object sender, EventArgs e)
        {
  SqlCommand cmd = new SqlCommand("UPDATE Musteri SET Adı=@ad,Soyadı=@soyad,telefon=@telefon,Adres=@adres WHERE MusteriID=@id ", baglanti);

     cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
    cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@telefon", textBox3.Text);
            cmd.Parameters.AddWithValue("@adres", textBox4.Text);


          
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
  cmd.ExecuteNonQuery();
  baglanti.Close();
 kayitGetir();
 //clear();
 MessageBox.Show("Güncellendi.");
        }
    }
}
