using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArizaTakip.Data
{
    public class Personel
    {
        public int perID { get; set; }
        public string perAdsoyad { get; set; }
        public string perTelefon { get; set; }
        public string perTc { get; set; }
        public string perMail { get; set; }

        public Personel()
        {
            this.perID = -1;
            this.perAdsoyad = string.Empty;
            this.perMail = string.Empty;
            this.perTc = string.Empty;
            this.perTelefon = string.Empty;
        }
   
    }
}
