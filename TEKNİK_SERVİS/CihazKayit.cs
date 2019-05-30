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
    public partial class CihazKayit : Form
    {
        private string nesne;
        public static string baglanticumlesi = (@" Data Source=.\SQLEXPRESS;Initial Catalog=TeknikServis;Integrated Security=true;");
        SqlConnection baglanti = new SqlConnection(baglanticumlesi);
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
      
        DataTable dt = new DataTable();

        //LİSWİEVLERE VERİTABANINDAN VERİ CEKTİK
        private void listwievmusteriverigetir()
        {
            baglanti.Open();
            komut = new SqlCommand("Select * From Musteri", baglanti);
            SqlDataReader rdr = komut.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem li = new ListViewItem(rdr["MusteriID"].ToString());
                li.SubItems.Add(rdr["Adı"].ToString());
                li.SubItems.Add(rdr["Soyadı"].ToString());
                li.SubItems.Add(rdr["Adres"].ToString());
                li.SubItems.Add(rdr["Telefon"].ToString());
                listView3.Items.Add(li);
            }
            baglanti.Close();
        


        }
        private void listwievturverigetir()
        {
            baglanti.Open();
            komut = new SqlCommand("Select * From CihazTuru", baglanti);
            SqlDataReader rdr = komut.ExecuteReader();

            while (rdr.Read())
            {
                ListViewItem li = new ListViewItem(rdr["TurID"].ToString());
                li.SubItems.Add(rdr["CihazTuru"].ToString());
                listView2.Items.Add(li);
            }
            baglanti.Close();
        }
        private void listwievmarkaverigetir()
        {
            baglanti.Open();
            komut = new SqlCommand("Select * From Marka", baglanti);
        SqlDataReader    rdr = komut.ExecuteReader();
            
            while (rdr.Read())
            {
                ListViewItem li = new ListViewItem(rdr["MarkaID"].ToString());
                li.SubItems.Add(rdr["MarkaAdi"].ToString());
                listView1.Items.Add(li);
            }
            baglanti.Close();
        }
        //LİSWİEVLERE VERİTABANINDAN VERİ CEKME İŞLEMİ SONA ERDİ

        //combobaxlara veritabanından ıdleri cektik
        private void combobax1vericek()
        {
            baglanti.Open();
            komut = new SqlCommand("Select * From CihazTuru", baglanti);
           SqlDataReader  rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                comboBox1.Items.Add(rdr["TurID"]);
            }
            baglanti.Close();
        }
        private void combobax2vericek()
        {
            baglanti.Open();
            komut = new SqlCommand("Select * From Marka", baglanti);
            SqlDataReader rdr = komut.ExecuteReader();
            while (rdr.Read())
            {
                comboBox2.Items.Add(rdr["MarkaID"]);
            }
            baglanti.Close();
        }
        //combobaxlara veri cekme işlemi sona erdi

        //datagridwiev a veri cektik
        private void kayitGetir()
        {
            baglanti.Open();
            string kayit = "SELECT * from CihazKayit";
            komut = new SqlCommand(kayit, baglanti);
            da = new SqlDataAdapter(komut);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }
        //datagridview a veri cekme işlemi sona erdi
        public CihazKayit()
        {
            InitializeComponent();
        }

        private void CihazKayit_Load(object sender, EventArgs e)
        {
            kayitGetir();
            listwievmarkaverigetir();
            listwievturverigetir();
            listwievmusteriverigetir();
            combobax1vericek();
            combobax2vericek();

        }

        private void verigir()
        {

            SqlCommand cmd = new SqlCommand("INSERT INTO CihazKayit (MusteriID,TurID,MarkaID,Model,SeriNo,GelisTarihi,SikayetAriza,ServistekiDurumu) VALUES (@musteriid,@turid,@markaid,@model,@serino,@gelistarihi,@sikayetariza,@servisdurumu)", baglanti);


            cmd.Parameters.AddWithValue("@musteriid", textBox1.Text);
            cmd.Parameters.AddWithValue("@turid", comboBox1.Text);
            cmd.Parameters.AddWithValue("@markaid", comboBox2.Text);
            cmd.Parameters.AddWithValue("@model", textBox2.Text);
            cmd.Parameters.AddWithValue("@serino", textBox3.Text);
            cmd.Parameters.AddWithValue("@gelistarihi", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@sikayetariza", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@servisdurumu", comboBox3.Text);
           
           
            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            cmd.ExecuteNonQuery();
            baglanti.Close();
            kayitGetir();
            //clear();
            MessageBox.Show("Verilen Eklendi");
        }
        private void clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text =  richTextBox1.Text=comboBox1.Text=comboBox2.Text=comboBox3.Text ="";

        }
        private void button1_Click(object sender, EventArgs e)
        {
            verigir();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE FROM CihazKayit WHERE KayitNo=@id", baglanti);

            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);


            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }

            cmd.ExecuteNonQuery(); baglanti.Close();
            kayitGetir();


            MessageBox.Show("Silindi.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("UPDATE CihazKayit SET Model=@model,SeriNo=@serino,GelisTarihi=@gelistarihi, SikayetAriza=@sikayetariza,ServistekiDurumu=@servisdurumu   WHERE KayitNo=@id ", baglanti);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);
          
            cmd.Parameters.AddWithValue("@model", textBox2.Text);
            cmd.Parameters.AddWithValue("@serino", textBox3.Text);
            cmd.Parameters.AddWithValue("@gelistarihi", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@sikayetariza", richTextBox1.Text);
            cmd.Parameters.AddWithValue("@servisdurumu", comboBox3.Text);


            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            cmd.ExecuteNonQuery();
            baglanti.Close();
            kayitGetir();
            //clear();
            MessageBox.Show("Verilen Güncellendi");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Onarımİslemleri gel = new Onarımİslemleri();
            gel.Show();
        }

       
    }
}
