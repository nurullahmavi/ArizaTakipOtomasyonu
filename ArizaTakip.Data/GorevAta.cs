using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArizaTakip.Data
{
    public class GorevAta
    {
        public int teknisyenAtaID { get; set; }
        public string Asil { get; set; }
        public string yedek1 { get; set; }
        public string yedek2 { get; set; }
        public string yedek3 { get; set; }

        public GorevAta()
        {
            this.teknisyenAtaID = -1;
            this.Asil = String.Empty;
            this.yedek1 = String.Empty;
            this.yedek2 = String.Empty;
            this.yedek3 = String.Empty;
        }
    }
}
