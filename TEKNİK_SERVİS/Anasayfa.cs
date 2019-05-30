using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TEKNİK_SERVİS
{
    public partial class Anasayfa : Form
    {
        public Anasayfa()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MüsteriKayit gel = new MüsteriKayit();
            gel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CihazKayit gel = new CihazKayit();
            gel.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Onarımİslemleri gel = new Onarımİslemleri();
            gel.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bilgialma gel = new bilgialma();
            gel.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            markamodel gel = new markamodel();
            gel.Show();
        }
    }
}
