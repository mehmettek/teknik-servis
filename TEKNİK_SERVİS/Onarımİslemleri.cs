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
    public partial class Onarımİslemleri : Form
    {
        private string nesne;
        public static string baglanticumlesi = (@" Data Source=.\SQLEXPRESS;Initial Catalog=TeknikServis;Integrated Security=true;");
        SqlConnection baglanti = new SqlConnection(baglanticumlesi);
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();

        DataTable dt = new DataTable();
        public Onarımİslemleri()
        {
            InitializeComponent();
        }
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

        private void button1_Click(object sender, EventArgs e)
        {
 SqlCommand cmd = new SqlCommand("UPDATE CihazKayit SET ServistekiDurumu=@servisdurumu,OnarımBitisTarihi=@onarimbitis ,Fiyat=@fiyat WHERE KayitNo=@id ", baglanti);
            cmd.Parameters.AddWithValue("@id", dataGridView1.CurrentRow.Cells[0].Value);     
            cmd.Parameters.AddWithValue("@servisdurumu", comboBox3.Text);
            cmd.Parameters.AddWithValue("@fiyat", textBox4.Text);
           cmd.Parameters.AddWithValue("@onarimbitis", dateTimePicker2.Text);
      


            if (baglanti.State == ConnectionState.Closed)
            {
                baglanti.Open();
            }
            cmd.ExecuteNonQuery();
            baglanti.Close();
           
            
            kayitGetir();
            MessageBox.Show("Verilen Güncellendi");
        }

        private void Onarımİslemleri_Load(object sender, EventArgs e)
        {
            kayitGetir();
        }
    }
}
