using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArizaTakip.Data
{
    public class Ariza
    {
        public int ID { get; set; }
        public int perID { get; set; }
        public DateTime bilidirimZamani { get; set; }
        public string ArizaDetay { get; set; }
        public string islem { get; set; }
        public DateTime MudahaleZamani { get; set; }
        public int malzemeID { get; set; }
        public string uzmanAta { get; set; }
        public string teknisyenAta { get; set; }
        public string rapor { get; set; }
        public string arizaYeri { get; set; }

        public int durumID { get; set; }

        public Ariza()
        {
            this.bilidirimZamani = DateTime.Now;
            this.MudahaleZamani = DateTime.Now;
            this.ArizaDetay = string.Empty;
            this.ID = -1;
            this.islem = string.Empty;
            this.malzemeID = -1;
            this.teknisyenAta = string.Empty;
            this.arizaYeri = string.Empty;
            this.perID = -1;
            this.uzmanAta = string.Empty;
            this.durumID = -1;
            this.rapor = string.Empty;
        }
    }
}
