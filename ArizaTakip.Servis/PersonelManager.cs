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
    public class PersonelManager : Personel
    {
        public void PersonelEkle()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_PersonelEkle";

                    cmd.Parameters.AddWithValue("@perTc", perTc);
                    cmd.Parameters.AddWithValue("@perMail", perMail);
                    cmd.Parameters.AddWithValue("@perAdSoyad", perAdsoyad);
                    cmd.Parameters.AddWithValue("@perTelefon", perTelefon);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public DataTable PersonelList()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_PersonelListele";

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;




        }

        public void PersonelUpdate()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_PersonelGuncelle";
                    cmd.Parameters.AddWithValue("@perTc", perTc);
                    cmd.Parameters.AddWithValue("@perMail", perMail);
                    cmd.Parameters.AddWithValue("@perAdSoyad", perAdsoyad);
                    cmd.Parameters.AddWithValue("@perTelefon", perTelefon);
                    cmd.Parameters.AddWithValue("@perID", perID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }


        public void PersonelDelete()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_PersonelSil";

                    cmd.Parameters.AddWithValue("@perID", perID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }
    }
}
