using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArizaTakip.Data;

namespace ArizaTakip.Servis
{
    public class GorevAtaManager : GorevAta
    {
        public void GorevAta()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_TeknisyenEkle";

                    cmd.Parameters.AddWithValue("@Asil", Asil);
                    cmd.Parameters.AddWithValue("@yedek1", yedek1);
                    cmd.Parameters.AddWithValue("@yedek2", yedek2);
                    cmd.Parameters.AddWithValue("@yedek3", yedek3);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }
    }
}
