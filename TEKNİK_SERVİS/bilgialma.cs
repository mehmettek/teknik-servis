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
    public partial class bilgialma : Form
    {
        public bilgialma()
        {
            InitializeComponent();
        }
        public static string baglanticumlesi = (@" Data Source=.\SQLEXPRESS;Initial Catalog=TeknikServis;Integrated Security=true;");
        SqlConnection baglanti = new SqlConnection(baglanticumlesi);
        
        SqlCommand komut = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
       //Toplam Ciromuzu hesapladık
        private void toplamcirom()
        {
           baglanti.Open();
           komut  = new SqlCommand("select SUM(Fiyat) as 'Toplam Cirom' from CihazKayit", baglanti);
            da = new SqlDataAdapter(komut);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        
        }
        //Cihazların Servisteki Durumu
        private void servisdurum()
        {
            baglanti.Open();
            string sorgu = "select c.KayitNo , m.Adı,m.Soyadı,ma.MarkaAdi ,c.ServistekiDurumu  from CihazKayit inner join Musteri m on m.MusteriID = c.MusteriID  inner join Marka ma on ma.MarkaID=c.MarkaID";
             komut=new SqlCommand(sorgu,baglanti);
            da = new SqlDataAdapter(komut);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            baglanti.Close();
        }
        //Teslim Edilecek Cihaz Sayısını Hesapladık
        private void teslimedilecekcihazsayısı()
        {
            baglanti.Open();
 komut = new SqlCommand("select COUNT(c.ServistekiDurumu) as 'Teslim Edilecek Cihaz Sayısı' from CihazKayit c where ServistekiDurumu='Teslim Edilecek' ", baglanti);
            da = new SqlDataAdapter(komut);
            dt = new DataTable();
            da.Fill(dt);
            dataGridView3.DataSource = dt;
            baglanti.Close();
        }
        private void bilgialma_Load(object sender, EventArgs e)
        {
            toplamcirom();
           servisdurum();
            teslimedilecekcihazsayısı();
        }

       
    }
}
