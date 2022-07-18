using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ArizaTakip.Servis
{
    public class csConnection
    {
        public static SqlConnection SqlCon()
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "Data Source=nurullahmavi\\SQLSERVER;Initial Catalog=FaultsTracking;Integrated Security=True";
            return con;

        }
    }
}
