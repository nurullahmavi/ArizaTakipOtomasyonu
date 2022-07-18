using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using ArizaTakip.Data;

namespace ArizaTakip.Servis
{
    public class YonetimManager : Yonetim
    {
        // <SHA256> Password Converter Method();
        private class Sha256Converter
        {
            public static string ComputeSha256Hash(string rawData)
            {
                // Create a SHA256   
                using (SHA256 sha256Hash = SHA256.Create())
                {
                    // ComputeHash - returns byte array  
                    byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                    // Convert byte array to a string   
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        builder.Append(bytes[i].ToString("x2"));
                    }
                    return builder.ToString();
                }
            }
        }

        /// </SHA256>


        public DataTable YonetimList()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_YonetimListele";

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;
        }

        public void YonetimEkle()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_YonetimEkle";
                    string Converted_Password = Sha256Converter.ComputeSha256Hash(Sifre);
                    cmd.Parameters.AddWithValue("@AdiSoyadi", AdiSoyadi);
                    cmd.Parameters.AddWithValue("@Tc", Tc);
                    cmd.Parameters.AddWithValue("@Telefon", Telefon);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@yetkiID", yetkiID);
                    cmd.Parameters.AddWithValue("@Sifre", Converted_Password);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public void YonetimGuncelle()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_YonetimGuncelle";
                    string Converted_Password = Sha256Converter.ComputeSha256Hash(Sifre);
                    cmd.Parameters.AddWithValue("@AdiSoyadi", AdiSoyadi);
                    cmd.Parameters.AddWithValue("@Tc", Tc);
                    cmd.Parameters.AddWithValue("@Telefon", Telefon);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@yetkiID", yetkiID);
                    cmd.Parameters.AddWithValue("@Sifre", Converted_Password);
                    cmd.Parameters.AddWithValue("@yonetimID", yonetimID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public void YonetimSil()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_YonetimSil";

                    cmd.Parameters.AddWithValue("@yonetimID", yonetimID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public void BilgilerimiGuncelle()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_BiligilerimiGuncelle";
                    string Converted_Password = Sha256Converter.ComputeSha256Hash(Sifre);
                    cmd.Parameters.AddWithValue("@AdiSoyadi", AdiSoyadi);
                    cmd.Parameters.AddWithValue("@Tc", Tc);
                    cmd.Parameters.AddWithValue("@Telefon", Telefon);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    cmd.Parameters.AddWithValue("@Sifre", Converted_Password);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }


        public DataTable TeknisyenList()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_TeknisyenListele";

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;
        }

        public DataTable TeknisyenAra()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_TeknisyenAra";
                    cmd.Parameters.AddWithValue("@AdiSoyadi", AdiSoyadi);


                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;
        }

    }
}
