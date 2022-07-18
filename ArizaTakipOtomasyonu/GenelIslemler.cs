using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using ArizaTakip.Servis;
using ArizaTakip.Data;

namespace ArizaTakipOtomasyonu
{
    class GenelIslemler
    {
        public void ComboDoldur(ComboBox cmb, string _DisplayMember, string _ValueMember, string CekilecekProsedur)
        {

            DataTable dtb = new DataTable();
            using (SqlConnection con = csConnection.SqlCon())
            {
                using (SqlCommand cmd = con.CreateCommand())
                {
                    con.Open();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = CekilecekProsedur;


                    using (SqlDataAdapter adap = new SqlDataAdapter(cmd))
                    {

                        adap.Fill(dtb);
                    }

                    con.Close();
                }

            }
            cmb.DataSource = dtb;
            cmb.DisplayMember = _DisplayMember;
            cmb.ValueMember = _ValueMember;




        }


        
        public string perAdsoyad;
        public DateTime bilidirim;
        public string Ariza;
        public string teknisyenAta;
        public string Durum;
        public string yAdSoyad;
        public string rapor;
        public void ArizaDetayButtonu(int id)
        {

            using (SqlConnection con = csConnection.SqlCon())
            {
                
                SqlCommand cmd = new SqlCommand("SELECT T_Ariza.ID,T_Personeller.perAdSoyad,T_Ariza.bildirimZamani,T_Ariza.Ariza,T_Ariza.teknisyenAta, T_IsDurum.Durum, T_Yonetim.AdiSoyadi,T_Ariza.rapor FROM T_Ariza LEFT JOIN T_Personeller ON T_Ariza.perID = T_Personeller.perID LEFT JOIN T_Malzemeler ON T_Ariza.malzemeID = T_Malzemeler.malzemeID LEFT JOIN T_IsDurum ON T_Ariza.durumID = T_IsDurum.durumID LEFT JOIN T_Yonetim ON T_Ariza.uzmanAta = T_Yonetim.Tc where ID = @ID", con);

                cmd.Parameters.AddWithValue("@Id", id);
                con.Open();
                SqlDataReader sql = cmd.ExecuteReader();
                    while (sql.Read())
                    {
                        perAdsoyad = sql.GetString(1);
                        bilidirim = sql.GetDateTime(2);
                        Ariza = sql.GetString(3);
                        teknisyenAta = sql.GetString(4);
                        Durum = sql.GetString(5);
                        yAdSoyad = sql.GetString(6);
                        rapor = sql.GetString(7);
                    }
                    con.Close();
                    
            }
        }

        public string calAdSoyad;
        public string calTc;
        public string calEmail;
        public string calTelefon;
        public string calSifre;
        public int calYetki;
        public void HesapBiligleri(string tc)
        {

            using (SqlConnection con = csConnection.SqlCon())
            {

                SqlCommand cmd = new SqlCommand("select * from T_Yonetim where Tc=@tc and IsActive =1", con);

                cmd.Parameters.AddWithValue("@tc", tc);
                con.Open();
                SqlDataReader sql = cmd.ExecuteReader();
                while (sql.Read())
                {
                    calAdSoyad = sql.GetString(1);
                    calTc = sql.GetString(2);
                    calEmail = sql.GetString(3);
                    calTelefon = sql.GetString(4);
                    calSifre = sql.GetString(5);
                    calYetki = sql.GetInt32(6);
                }
                con.Close();
                //KontrolEtTc = (string)komut.ExecuteScalar();
            }
        }



    }
}
