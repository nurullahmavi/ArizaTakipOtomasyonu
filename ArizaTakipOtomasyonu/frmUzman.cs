using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArizaTakip.Servis;

namespace ArizaTakipOtomasyonu
{
    public partial class frmUzman : Form
    {
        static int _ID = -1;
        ArizaManager ariza = new ArizaManager();
        YonetimManager yonetim = new YonetimManager();
        csConnection con = new csConnection();
        GenelIslemler genel = new GenelIslemler();
        public frmUzman()
        {
            InitializeComponent();
            bunifuFormDock1.SubscribeControlToDragEvents(panel1);
            bunifuFormDock1.SubscribeControlToDragEvents(panel2);
        }
        void gridDoldur()
        {
            ariza.uzmanAta = Convert.ToString(frmLogin._tc);
            dtgYeniIs.DataSource = ariza.IdeyeGoreListele();
            dtgIslerim.DataSource = ariza.IslerimiListele();
        }
        void comboFill()
        {
            genel.ComboDoldur(cmbMalzeme, "malzemeAd", "malzemeID", "Sp_MalzemeListele");

        }
        private void btnIslerim_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("islerim");
        }

        private void btnYeni_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("yeni");
        }

        private void btnHesabım_Click(object sender, EventArgs e)
        {
            pSec.Top = ((Control)sender).Top;
            sayfalar.SetPage("hesabim");
            txtHesapAdSoyad.Text = genel.calAdSoyad;
            txtHesapEmail.Text = genel.calEmail;
            txtHesapTc.Text = genel.calTc;
            txtHesapTelefon.Text = genel.calTelefon;
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

        private void btnKabulEt_Click(object sender, EventArgs e)
        {
            ariza.ID = _ID;
            ariza.durumID = 1;
            ariza.ArizaDurumUpdate();
            gridDoldur();
            lblSecilenIs.Text = " ";
        }

        private void dtgYeniIs_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _ID = Convert.ToInt32(dtgYeniIs.CurrentRow.Cells[0].Value);
            lblSecilenIs.Text = dtgYeniIs.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnRedEt_Click(object sender, EventArgs e)
        {
            if (_ID > 0)
            {
                grpRapor.Visible = true;
            }
            else
            {
                grpRapor.Visible = false;
                MessageBox.Show("İş Seçilmedi");
            }
        }

        private void btnRedGonder_Click(object sender, EventArgs e)
        {
            ariza.ID = _ID;
            ariza.rapor = txtRedSebebi.Text;
            ariza.ArizaRaporUpdate();
            ariza.durumID = 4;
            ariza.ArizaDurumUpdate();
            grpRapor.Visible = false;
            gridDoldur();
        }

        private void dtgIslerim_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            _ID = Convert.ToInt32(dtgIslerim.CurrentRow.Cells[0].Value);
            lblIslerimSecilen.Text = dtgIslerim.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnIsTamamla_Click(object sender, EventArgs e)
        {

            if (_ID == -1)
            {
                MessageBox.Show("Herhangi Bir Kayıt Seçilmedi!");
            }

            else
            {

                ariza.ID = _ID;
                ariza.islem = txtIslem.Text;
                ariza.malzemeID = Convert.ToInt32(cmbMalzeme.SelectedValue);

                ariza.MudahaleZamani = Convert.ToDateTime(dtpMudahaleZamani.Text);


                ariza.ArizaUpdate();

                gridDoldur();

                _ID = -1;
            }
        }

        private void frmUzman_Load(object sender, EventArgs e)
        {
            gridDoldur();
            comboFill();
            genel.HesapBiligleri(frmLogin._tc);
            lblAdSoyad.Text = genel.calAdSoyad;
        }

        private void btnBilgiGuncelle_Click(object sender, EventArgs e)
        {


            if (txtHesapAdSoyad.Text != "" && txtHesapEmail.Text != "" && txtHesapTelefon.Text != "" && txtHesapSifre.Text != "")
            {

                if (txtHesapTelefon.Text.Length < 11 || txtHesapTelefon.Text.Length > 11)
                {
                    MessageBox.Show("Telefon Numarası 11 Karekterli Olmalıdır");
                }
                else
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

            }
            else
            {
                MessageBox.Show("Lütfen Tüm Alanları Eksiksiz Doldurun");
            }
        }

        private void islerim_Click(object sender, EventArgs e)
        {

        }
    }
}
