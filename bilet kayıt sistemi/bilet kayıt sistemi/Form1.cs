using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
namespace bilet_kayıt_sistemi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglanti = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=\"C:\\Users\\doğukan\\OneDrive\\Masaüstü\\c# dersleri\\ACCESS VERİ TABANI\\Access Yolcu Bilet Rezervasyon\\bilet.mdb\"");

        private void verilerigoster() 
        {
            baglanti.Open();
            OleDbCommand komut = new OleDbCommand();
            komut.Connection = baglanti;
            komut.CommandText = "select * from bilgiler";
            OleDbDataReader oku = komut.ExecuteReader();

            while (oku.Read()) 
            {
                ListViewItem ekle = new ListViewItem();
                ekle.Text = oku["seferno"].ToString();
                ekle.SubItems.Add(oku["tarih"].ToString());
                ekle.SubItems.Add(oku["saat"].ToString());
                ekle.SubItems.Add(oku["ad soyad"].ToString());
                ekle.SubItems.Add(oku["telefon"].ToString());
                ekle.SubItems.Add(oku["koltuk no"].ToString());
                ekle.SubItems.Add(oku["ücret"].ToString());
                ekle.SubItems.Add(oku["cinsiyet"].ToString());
                ekle.SubItems.Add(oku["biniş"].ToString());


                listView1.Items.Add(ekle);
            }
            baglanti.Close();// bu kodu döngünün dışında yazmak önemlidir!!!!!!!
        }
        private void button1_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            // AŞŞAĞIDAKİ KODDA HATA ALMAMAK ADINA TÜRKÇE KARAKTER İÇEREN , ALAN ADINDA BOŞLUK OLAN
            // VE TARİH SAAT GİBİ ALAN ADLARI KÖŞELİ PARANTEZE ALINMALIDIR YOKSA HATA VERİR
            OleDbCommand komut = new OleDbCommand("INSERT INTO bilgiler (seferno,[tarih],[saat],[ad soyad],telefon,[koltuk no],[ücret],cinsiyet,[biniş]) values('"+textBox1.Text.ToString()
                +"','"+textBox2.Text.ToString()+ "','"+textBox3.Text.ToString()+ "','"+textBox4.Text.ToString()
                + "','"+textBox5.Text.ToString()+ "','"+textBox6.Text.ToString()+ "','"+textBox7.Text.ToString()+ "','"+comboBox2.Text.ToString()+ "','"+comboBox1.Text.ToString()+"')",baglanti);
            
            komut.ExecuteNonQuery();
          
            baglanti.Close();
            verilerigoster();


        }
    }
}
