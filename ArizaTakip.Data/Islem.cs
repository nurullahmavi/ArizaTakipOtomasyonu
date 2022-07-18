using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArizaTakip.Data
{
    public class Islem
    {
        public int islemID { get; set; }
        public string islem { get; set; }

        public Islem()
        {
            this.islemID = -1;
            this.islem = string.Empty;

        }
    }
}
