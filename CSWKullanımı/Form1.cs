using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSWKullanımı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Personel> Personellist = new List<Personel>();

        private void button2_Click(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("C:\\CSV\\CsvPersonel.csv");
            CsvHelper.CsvReader read = new CsvHelper.CsvReader(sr);
            List<Personel> personellist = read.GetRecords<Personel>().ToList();
            listBox1.DataSource = personellist;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Matematikselslemler.Islemler m = new Matematikselslemler.Islemler();
            int toplam = m.topla(10, 20);

            for (int i = 1; i <= 10; i++)
            {
                Personel p = new Personel();
                p.ID = i;
                p.isim = FakeData.NameData.GetFirstName();
                p.soyisim = FakeData.NameData.GetSurname();
                p.tel = FakeData.PhoneNumberData.GetPhoneNumber();
                p.email = FakeData.NetworkData.GetEmail();

                Personellist.Add(p);
            }


            StreamWriter dosya = new StreamWriter("C:\\CSV\\CsvPersonel.csv");
            //dosyayı csv formatına dönüştürür
            CsvHelper.CsvWriter csv = new CsvHelper.CsvWriter(dosya);
            csv.WriteHeader(typeof(Personel)); //personel tipinden ne varsa başlık olarak vermesini istedik
            csv.WriteRecords(Personellist); //personel listesindeki kayıtları kayıt olarak vermesini istedik
            MessageBox.Show("CSV Dosya Oluşturuldu");
            dosya.Close();
        }
    }
}
