using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArizaTakip.Servis;

namespace ArizaTakipOtomasyonu
{
    public partial class frmSuperUserMain : Form
    {
        static int _ArizaID = -1;
        static int _perID = -1;
        static int _yonetimID = -1;

        ArizaManager ariza = new ArizaManager();
        GenelIslemler genel = new GenelIslemler();
        PersonelManager personel = new PersonelManager();
        YonetimManager yonetim = new YonetimManager();
        MalzameManager malzeme = new MalzameManager();
        public frmSuperUserMain()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(panel1);
            bunifuFormDock1.SubscribeControlToDragEvents(panel2);
            
        }
        void comboFill()
        {
            genel.ComboDoldur(cBoxYetki, "Yetki", "yetkiID", "Sp_YetkiListele");
            

        }

        void gridDoldur()
        {
            dtgIsler.DataSource = ariza.TamamlanaArizaLİist();
            dtgPersoneller.DataSource = personel.PersonelList();
            dtgCalisanlar.DataSource = yonetim.YonetimList();
            dtgMalzeme.DataSource = malzeme.MalzemeList();
        }

        private void btnAnasayfa_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("AnaSayfa");
        }

        private void btnIsler_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("Isler");
        }

        private void btnPersoneller_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("Personeller");
            txtPerAdSoyad.Focus();
        }

        private void btnCalisanlar_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("Calisanlar");
        }

        private void btnMalzemeler_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("Malzemeler");
        }

        private void btnHesabım_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("Hesabim");
            
            txtHesapAdSoyad.Text = genel.calAdSoyad;
            txtHesapEmail.Text = genel.calEmail;
            txtHesapTc.Text = genel.calTc;
            txtHesapTelefon.Text = genel.calTelefon;
            
        }

        private void frmSuperUserMain_Load(object sender, EventArgs e)
        {
            gridDoldur();
            comboFill();
            DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();
            dgvBtn.HeaderText = "";
            dgvBtn.Text = "Detay";
            dgvBtn.UseColumnTextForButtonValue = true;
            dgvBtn.DefaultCellStyle.BackColor = Color.Cyan;
            dgvBtn.DefaultCellStyle.SelectionBackColor = Color.White;
            dgvBtn.Width = 70;
            dtgIsler.Columns.Add(dgvBtn);
            genel.HesapBiligleri(frmLogin._tc);
            lblAdSoyad.Text = genel.calAdSoyad;
            
        }

        private void dtgIsler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
                _ArizaID = Convert.ToInt32(dtgIsler.CurrentRow.Cells["ID"].Value);
                if (e.ColumnIndex == 0)
                {

                    
                    genel.ArizaDetayButtonu(_ArizaID);
                    MessageBox.Show("Arızayı Bildiren Kişinin Adı Soyadı : " + genel.perAdsoyad + "\n" +
                        "Arıza Bilidrim Zamanı : " + genel.bilidirim + "\n" +
                        "Arıza Detayı : " + genel.Ariza + "\n" +
                        "Gönderilen Uzman : " + genel.bilidirim + "\n" +
                        "Gönderilen Teknisyenler : " + genel.teknisyenAta + "\n" +
                        "Arıza Durumu : " + genel.Durum+"\n"+
                        "Rapor : " + genel.rapor);

                }
            
            

        }

        private void btnTamamlanan_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Tamamlanan Arızalar";
            dtgIsler.DataSource = ariza.TamamlanaArizaLİist();
        }

        private void btnKabulEdilen_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Kabul Edilen İşler";
            dtgIsler.DataSource = ariza.KabulArizaList();
        }

        private void btnBeklenen_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Bekleyen İşler";
            dtgIsler.DataSource = ariza.ArizaList();
        }

        private void btnRedEdilen_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Red Edilen İşler";
            dtgIsler.DataSource = ariza.RedArizaList();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "İptal Edilen İşler";
            dtgIsler.DataSource = ariza.ArizaIptalList();
        }

        ///////////////////////Personeller///////////////////////////////////////

        public bool personelVarmi;
        SqlConnection con = csConnection.SqlCon();

        public void personelTekrarVarmi()
        {
            con.Open();
            SqlCommand komut = new SqlCommand("select * from T_Personeller where perTc=@_tc ", con);

            komut.Parameters.AddWithValue("@_tc", txtPerTc.Text);
            SqlDataReader sdr = komut.ExecuteReader();
            if (sdr.Read())
            {
                personelVarmi = false;
            }
            else
            {
                personelVarmi = true;
            }
            con.Close();
        }

        private void btnPersonelEkle_Click(object sender, EventArgs e)
        {
            personelTekrarVarmi();
            if(txtPerAdSoyad.Text != ""&& txtPerMail.Text != "" && txtPerTc.Text != "" && txtPerTelefon.Text != "")
            {
                if(txtPerTc.Text.Length<11 || txtPerTc.Text.Length > 11)
                {
                    MessageBox.Show("T.C. Numarası 11 Karekterli Olmalıdır");
                }
                else
                {
                    if (txtPerTelefon.Text.Length < 11 || txtPerTelefon.Text.Length > 11)
                    {
                        MessageBox.Show("Telefon Numarası 11 Karekterli Olmalıdır");
                    }
                    else
                    {
                        if (personelVarmi == true)
                        {
                            personel.perTc = txtPerTc.Text;
                            personel.perTelefon = txtPerTelefon.Text;
                            personel.perMail = txtPerMail.Text;
                            personel.perAdsoyad = txtPerAdSoyad.Text;
                            personel.PersonelEkle();
                            MessageBox.Show("Kayıt Eklendi");
                            gridDoldur();
                            txtPerAdSoyad.Clear();
                            txtPerTelefon.Clear();
                            txtPerMail.Clear();
                            txtPerTc.Clear();
                            txtPerAdSoyad.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Personel Zaten Kayıtlı");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun");
            }
        }

        private void dtgPersoneller_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _perID = Convert.ToInt32(dtgPersoneller.CurrentRow.Cells[0].Value);
            txtPerAdSoyad.Text = dtgPersoneller.CurrentRow.Cells[1].Value.ToString();
            txtPerTc.Text = dtgPersoneller.CurrentRow.Cells[2].Value.ToString();
            txtPerMail.Text = dtgPersoneller.CurrentRow.Cells[4].Value.ToString();
            txtPerTelefon.Text = dtgPersoneller.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnPersonelGuncelle_Click(object sender, EventArgs e)
        {
            personelTekrarVarmi();
            if (txtPerAdSoyad.Text != "" && txtPerMail.Text != "" && txtPerTc.Text != "" && txtPerTelefon.Text != "")
            {
                if (txtPerTc.Text.Length < 11 || txtPerTc.Text.Length > 11)
                {
                    MessageBox.Show("T.C. Numarası 11 Karekterli Olmalıdır");
                }
                else
                {
                    if (txtPerTelefon.Text.Length < 11 || txtPerTelefon.Text.Length > 11)
                    {
                        MessageBox.Show("Telefon Numarası 11 Karekterli Olmalıdır");
                    }
                    else
                    {
                        if (personelVarmi == true)
                        {
                            personel.perID = _perID;
                            personel.perTc = txtPerTc.Text;
                            personel.perTelefon = txtPerTelefon.Text;
                            personel.perMail = txtPerMail.Text;
                            personel.perAdsoyad = txtPerAdSoyad.Text;
                            personel.PersonelUpdate();
                            MessageBox.Show("Kayıt Güncellendi");
                            gridDoldur();
                            txtPerAdSoyad.Clear();
                            txtPerTelefon.Clear();
                            txtPerMail.Clear();
                            txtPerTc.Clear();
                            txtPerAdSoyad.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Personel Zaten Kayıtlı");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun");
            }
        }

        private void btnPersonelSil_Click(object sender, EventArgs e)
        {
            if (_perID == -1)
            {
                MessageBox.Show("Herhangi Bir Kayıt Seçilmedi!");
            }

            else
            {

                personel.perID = _perID;

                personel.PersonelDelete();

               gridDoldur();

                _perID = -1;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Çıkış Yapmak İstediğinizden Emin Misiniz", "Çıkış Yap", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secenek == DialogResult.Yes)
            {
                this.Hide();
                frmLogin login = new frmLogin();
                login.Show();
            }
        }

        ///////////////////////Calisan////////////////////////////

        public bool calisanVarmi;
        

        public void calisanTekrarVarmi()
        {
            con.Open();
            SqlCommand komut = new SqlCommand("select * from T_Yonetim where Tc=@_tc ", con);

            komut.Parameters.AddWithValue("@_tc", txtCalTc.Text);
            SqlDataReader sdr = komut.ExecuteReader();
            if (sdr.Read())
            {
                calisanVarmi = false;
            }
            else
            {
                calisanVarmi = true;
            }
            con.Close();
        }
        private void btnCalEkle_Click(object sender, EventArgs e)
        {
            calisanTekrarVarmi();
            if (txtCalAdSoyad.Text != "" && txtCalMail.Text != "" && txtCalTc.Text != "" && txtCalTelefon.Text != ""&&txtCalSifre.Text != "")
            {
                if (txtCalTc.Text.Length < 11 || txtCalTc.Text.Length > 11)
                {
                    MessageBox.Show("T.C. Numarası 11 Karekterli Olmalıdır");
                }
                else
                {
                    if (txtCalTelefon.Text.Length < 11 || txtCalTelefon.Text.Length > 11)
                    {
                        MessageBox.Show("Telefon Numarası 11 Karekterli Olmalıdır");
                    }
                    else
                    {
                        if (calisanVarmi == true)
                        {
                            yonetim.Tc = txtCalTc.Text;
                            yonetim.Sifre = txtCalSifre.Text;
                            yonetim.Telefon = txtCalTelefon.Text;
                            yonetim.AdiSoyadi = txtCalAdSoyad.Text;
                            yonetim.Email = txtCalMail.Text;
                            yonetim.yetkiID = Convert.ToInt32(cBoxYetki.SelectedValue);
                            yonetim.YonetimEkle();
                            MessageBox.Show("Kayıt Eklendi");
                            gridDoldur();
                            txtCalTc.Clear();
                            txtCalSifre.Clear();
                            txtCalTelefon.Clear();
                            txtCalAdSoyad.Clear();
                            txtCalMail.Clear();
                            txtCalAdSoyad.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Çalışan Zaten Kayıtlı");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun");
            }
        }

        private void dtgCalisanlar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _yonetimID = Convert.ToInt32(dtgCalisanlar.CurrentRow.Cells[0].Value);
            txtCalAdSoyad.Text = dtgCalisanlar.CurrentRow.Cells[1].Value.ToString();
            txtCalTc.Text = dtgCalisanlar.CurrentRow.Cells[2].Value.ToString();
            txtCalTelefon.Text = dtgCalisanlar.CurrentRow.Cells[4].Value.ToString();
            txtCalMail.Text = dtgCalisanlar.CurrentRow.Cells[3].Value.ToString();
            
            
        }

        private void btnCalGuncelle_Click(object sender, EventArgs e)
        {
            calisanTekrarVarmi();
            if (txtCalAdSoyad.Text != "" && txtCalMail.Text != "" && txtCalTc.Text != "" && txtCalTelefon.Text != "" && txtCalSifre.Text != "")
            {
                if (txtCalTc.Text.Length < 11 || txtCalTc.Text.Length > 11)
                {
                    MessageBox.Show("T.C. Numarası 11 Karekterli Olmalıdır");
                }
                else
                {
                    if (txtCalTelefon.Text.Length < 11 || txtCalTelefon.Text.Length > 11)
                    {
                        MessageBox.Show("Telefon Numarası 11 Karekterli Olmalıdır");
                    }
                    else
                    {
                        if (calisanVarmi == true)
                        {
                            yonetim.yonetimID = _yonetimID;
                            yonetim.Tc = txtCalTc.Text;
                            yonetim.Sifre = txtCalSifre.Text;
                            yonetim.Telefon = txtCalTelefon.Text;
                            yonetim.AdiSoyadi = txtCalAdSoyad.Text;
                            yonetim.Email = txtCalMail.Text;
                            yonetim.yetkiID = Convert.ToInt32(cBoxYetki.SelectedValue);
                            yonetim.YonetimGuncelle();
                            MessageBox.Show("Kayıt Güncellendi");
                            gridDoldur();
                            txtCalTc.Clear();
                            txtCalSifre.Clear();
                            txtCalTelefon.Clear();
                            txtCalAdSoyad.Clear();
                            txtCalMail.Clear();
                            txtCalAdSoyad.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Çalışan Zaten Kayıtlı");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun");
            }
        }

        private void btnCalSil_Click(object sender, EventArgs e)
        {
            if(_yonetimID > -1)
            {
                yonetim.yonetimID = _yonetimID;
                yonetim.YonetimSil();
                MessageBox.Show("Kayıt Silindi");
                gridDoldur();
                _yonetimID = -1;
            }
        }

        ///////////////////////////////////Malzeme
        private void btnMalzemeEkle_Click(object sender, EventArgs e)
        {
            if (txtMalzeme.Text != "")
            {
                malzeme.malzemeAd = txtMalzeme.Text;

                malzeme.MalzemeEkle();
                gridDoldur();
            }
        }
        static int _malzemeID = -1;
        private void btnMalzemeSil_Click(object sender, EventArgs e)
        {
            if (_malzemeID == -1)
            {
                MessageBox.Show("Herhangi Bir Kayıt Seçilmedi!");
            }

            else
            {

                malzeme.malzemeID = _malzemeID;

                malzeme.MalzemeDelete();

                gridDoldur();

                _malzemeID = -1;
            }
        }

        private void dtgMalzeme_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _malzemeID = Convert.ToInt32(dtgMalzeme.CurrentRow.Cells[0].Value);
            txtMalzeme.Text = dtgMalzeme.CurrentRow.Cells[1].Value.ToString();
        }
        
        //////////////////////Hesap Bilgileri
        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {

            
            calisanTekrarVarmi();
            if (txtHesapAdSoyad.Text != "" && txtHesapEmail.Text != "" && txtHesapTelefon.Text != "" && txtHesapSifre.Text != "")
            {
                
                    if (txtHesapTelefon.Text.Length < 11 || txtHesapTelefon.Text.Length > 11)
                    {
                        MessageBox.Show("Telefon Numarası 11 Karekterli Olmalıdır");
                    }
                    else
                    {
                        if (calisanVarmi == false)
                        {
                            
                            yonetim.Tc = frmLogin._tc;
                            
                            yonetim.Sifre = txtHesapSifre.Text;
                            yonetim.Telefon = txtHesapTelefon.Text;
                            yonetim.AdiSoyadi = txtHesapAdSoyad.Text;
                            yonetim.Email = txtHesapEmail.Text;
                            
                            yonetim.BilgilerimiGuncelle();
                            MessageBox.Show("Bilgileriniz Güncellendi");
                            this.Refresh();
                        }
                        else
                        {
                            MessageBox.Show("Bilgileriniz başka kullanıcı ile çakıştı");
                        }
                    }
                
            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun");
            }
        }

        private void dtgIsler_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            if(bunifuTextBox1.Text.Length > 2)
            {
                ariza.ArizaDetay = bunifuTextBox1.Text;
                yonetim.Tc = bunifuTextBox1.Text;
                personel.perTc = bunifuTextBox1.Text;
                dtgIsler.DataSource = ariza.IsAra();
            }
            else
            {
                gridDoldur();
            }
        }
    }
}
