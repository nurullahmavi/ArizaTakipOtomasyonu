using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArizaTakip.Data
{
    public class Yonetim
    {
        public int yonetimID { get; set; }
        public string AdiSoyadi { get; set; }
        public string Tc { get; set; }
        public string Email { get; set; }
        public string Telefon { get; set; }
        public string Sifre { get; set; }
        public int yetkiID { get; set; }

        public Yonetim()
        {
            this.yonetimID = 1;
            this.yetkiID = -1;
            this.AdiSoyadi = string.Empty;
            this.Tc = string.Empty;
            this.Email = string.Empty;
            this.Telefon = string.Empty;
            this.Sifre = string.Empty;
        }

        
    }
}
