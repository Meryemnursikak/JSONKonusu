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

namespace JSONKonusu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<Personel> Personellist = new List<Personel>();
        private void button1_Click(object sender, EventArgs e)
        {
            

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

            if (!Directory.Exists("C:\\JSON"))
            {
                Directory.CreateDirectory("C:\\JSON");
            }

            //json formatında oluşturmak için serilaze ederiz.
            string jsonpersoneller = Newtonsoft.Json.JsonConvert.SerializeObject(Personellist);
            File.WriteAllText("C:\\JSON\\Personeller.json", jsonpersoneller);

            MessageBox.Show("JSON Data Oluşturuldu");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string okunandosya = File.ReadAllText("C:\\JSON\\Personeller.json");
            //json formatındaki datayı normal dataya dönüştürmek için deserilaze ederiz
            List<Personel> liste = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Personel>>(okunandosya);

            listBox1.DataSource = liste;
        }
    }
}
