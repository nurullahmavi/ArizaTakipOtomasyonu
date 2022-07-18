using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArizaTakip.Data
{
    public class Malzeme
    {
        public int malzemeID { get; set; }
        public string malzemeAd { get; set; }

        public Malzeme()
        {
            this.malzemeID = -1;
            this.malzemeAd = string.Empty;
        }
    }
}
