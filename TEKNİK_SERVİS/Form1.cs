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
    public partial class Form1 : Form
    {
       public static string baglanticumlesi = (@" Data Source=.\SQLEXPRESS;Initial Catalog=TeknikServis;Integrated Security=true;");
        SqlConnection baglanti = new SqlConnection(baglanticumlesi);
        SqlCommand komut = new SqlCommand();
        SqlDataReader oku;
        public Form1()
        {
            InitializeComponent();
        }
        void giris()
        {
            Anasayfa ana = new Anasayfa();
            ana.Show();

        }
        Boolean durum;
        private void button1_Click(object sender, EventArgs e)
        {
            giris();
             /*string adi, sifre;
              baglanti.Open();
              komut = new SqlCommand("SELECT * FROM kullanici ", baglanti);
              oku = komut.ExecuteReader();

              while (oku.Read())
              { 
                  adi=(oku["kullaniciadi"]).ToString();
                  sifre=(oku["sifre"]).ToString();

                  if (adi == textBox1.Text && sifre == textBox2.Text)
                  {
                      durum = true;
                     
                  }
              }
              if (durum)
      {
           giris();
      }
             else
 MessageBox.Show("Kullanıcı Adınız veya Şifreniz Geçersiz!!! \n Lütfen Geçerli Kullanıcı Adı ve Şifre Giriniz.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

              baglanti.Close(); */
          }

       

          private void button2_Click_1(object sender, EventArgs e)
          {
              Close();
          }

        }
    }
