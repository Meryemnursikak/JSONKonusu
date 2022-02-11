using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSONKonusu
{
    public class Personel
    {
        public int ID { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string tel { get; set; }
        public string email { get; set; }

        public override string ToString()
        {
            return isim+" "+soyisim;
        }
    }
}
