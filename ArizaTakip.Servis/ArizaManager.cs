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
    public class ArizaManager : Ariza
    {
        public void ArizaEkle()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_ArizaEkle";
                    cmd.Parameters.AddWithValue("@Ariza", ArizaDetay);
                    cmd.Parameters.AddWithValue("@teknisyenAta", teknisyenAta);
                    cmd.Parameters.AddWithValue("@bildirimZamani", bilidirimZamani);
                    cmd.Parameters.AddWithValue("@arizaYeri", arizaYeri);
                    cmd.Parameters.AddWithValue("@perID", perID);
                    cmd.Parameters.AddWithValue("@uzmanAta", uzmanAta);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public DataTable ArizaList()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_ArizaListele";

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;
        }

        public DataTable KabulArizaList()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_KabulArizaList";

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;
        }
        public DataTable RedArizaList()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_RedArizaList";

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;
        }

        public DataTable TamamlanaArizaLİist()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_PasifArizaListele";

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;
        }

        public void ArizaUpdate()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_ArizaGuncelle";
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@MudahaleZamani", MudahaleZamani);
                    cmd.Parameters.AddWithValue("@malzemeID", malzemeID);
                    cmd.Parameters.AddWithValue("@islem", islem);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public void ArizaDurumUpdate()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_ArizaDurumGuncelle";
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@durumID", durumID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }
        public void ArizaRaporUpdate()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_RaporEkle";
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@rapor", rapor);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }


        public void ArizaDelete()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_ArizaIptalEt";

                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        public DataTable IdeyeGoreListele()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_IdyeGoreListele";
                    cmd.Parameters.AddWithValue("@uzmanAta", uzmanAta);
                    

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;
        }

        public DataTable IslerimiListele()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_IslerimiListele";
                    cmd.Parameters.AddWithValue("@uzmanAta", uzmanAta);


                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;
        }

        public void ArizaIptalEt()
        {
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_ArizaIptalEt";
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }

        }

        

        public DataTable ArizaIptalList()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_ArizaIptalList";

                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            return dtb;
        }
        Yonetim yo = new Yonetim();
        Personel per = new Personel();
        public DataTable IsAra()
        {

            DataTable dtb = new DataTable();


            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = "Sp_IsAra";
                    cmd.Parameters.AddWithValue("@Ariza", ArizaDetay);
                    cmd.Parameters.AddWithValue("@yonetimTc", yo.Tc);
                    cmd.Parameters.AddWithValue("@perTc", per.perTc);


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
