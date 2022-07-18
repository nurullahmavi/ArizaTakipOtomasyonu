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
    public class IslemManager : Islem
    {
        public void IslemEkle()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_IslemEkle";

                    cmd.Parameters.AddWithValue("@islem", islem);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public DataTable IslemList()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_IslemListele";

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;




        }

        public void IslemDelete()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_IslemSil";

                    cmd.Parameters.AddWithValue("@islemID", islemID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }
    }
}
