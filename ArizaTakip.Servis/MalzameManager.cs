using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArizaTakip.Data;

namespace ArizaTakip.Servis
{
    
    public class MalzameManager : Malzeme
    {
        public void MalzemeEkle()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_MalzemeEkle";

                    cmd.Parameters.AddWithValue("@malzemeAd", malzemeAd);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public DataTable MalzemeList()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_MalzemeListele";

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;




        }

        public void MalzemeDelete()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_MalzemeSil";

                    cmd.Parameters.AddWithValue("@malzemeID", malzemeID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }
    }
}
